using AutoMapper;
using Petiza.Catalogo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Petiza.Catalogo.Domain;
using System.IO;
using System.Net.Http.Headers;
using Amazon;
using Amazon.Internal;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using Bogus;

namespace Petiza.Catalogo.Application.Services
{
    public class AnimalApplicationService : IAnimalApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IAnimalRepository _animalRepository;

        private const string bucketName = "paulocampez";
        //private const string keyName = "*** provide a name for the uploaded object ***";
        //private const string filePath = "*** provide the full path name of the file to upload ***";
        // Specify your bucket region (an example region is shown).
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.SAEast1;
        private IAmazonS3 s3Client;
        public AnimalApplicationService(IMapper mapper, IAnimalRepository animalRepository)
        {
            _mapper = mapper;
            _animalRepository = animalRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Foo()
        {

        }

        public async Task AdicionarAnimal(AnimalViewModel AnimalViewModel)
        {
            AnimalViewModel.Imagem = SetarUrlImagem(AnimalViewModel);
            AnimalViewModel.CategoriaId = Guid.Parse("4ee35607-2d8d-4e45-a21d-167ff918ee74");
            //AnimalViewModel.Categorias = new Categoria("Cachorro", 1) { Id = Guid.Parse("4ee35607-2d8d-4e45-a21d-167ff918ee74") };
            AdicionarImagem(AnimalViewModel.File, AnimalViewModel.Imagem);

            var Animal = _mapper.Map<Animal>(AnimalViewModel);
            _animalRepository.Adicionar(Animal);

            await _animalRepository.UnitOfWork.Commit();
        }

        private string SetarUrlImagem(AnimalViewModel animalVM)
        {
            Random rnd = new Random();

            var faker = new Faker("pt_BR");
            var nomeId = RemoveSpecialCharacters(faker.Random.Words(rnd.Next(4, 7)).Trim());
            var name = nomeId + Path.GetExtension(animalVM.File.FileName);
            return name;
        }
        string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        private void AdicionarImagem(Microsoft.AspNetCore.Http.IFormFile file, string fileName)
        {
            if (true)
            {
                #region amazonUploads3

                try
                {
                    AWSCredentials credentials = new BasicAWSCredentials("", "");
                    s3Client = new AmazonS3Client(credentials, bucketRegion);

                    var fileTransferUtility =
                        new TransferUtility(s3Client);

                    using (Stream fileToUpload = file.OpenReadStream())
                    {
                        var fileTransferUtilityRequest = new TransferUtilityUploadRequest
                        {
                            BucketName = bucketName,
                            StorageClass = S3StorageClass.StandardInfrequentAccess,
                            Key = fileName,
                            CannedACL = S3CannedACL.PublicRead,
                            InputStream = fileToUpload
                        };

                        fileTransferUtility.Upload(fileTransferUtilityRequest);
                    }

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }

                #endregion
            }

            if (false)
            {
                try

                {
                    var folderName = Path.Combine("Resources", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    Console.WriteLine("CAMINHO: " + pathToSave);
                    if (file.Length > 0)
                    {
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERRO:" + ex.InnerException);
                }
            }
        }

        public async Task<IEnumerable<AnimalViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AnimalViewModel>>(await _animalRepository.ObterTodos());
        }
    }
}
