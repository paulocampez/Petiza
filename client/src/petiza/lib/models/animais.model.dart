class Animal {
  String id;
  String imageUrl;

  Animal({this.id, this.imageUrl});

  Animal.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    imageUrl = json['imageUrl'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['imageUrl'] = this.imageUrl;
    return data;
  }
}
