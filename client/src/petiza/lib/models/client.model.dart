import 'package:petiza/models/animais.model.dart';

class Cliente {
  String token;
  Animal animal;

  Cliente({this.token, this.animal});

  Cliente.fromJson(Map<String, dynamic> json) {
    token = json['token'];
    animal =
        json['animal'] != null ? new Animal.fromJson(json['animal']) : null;
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['token'] = this.token;
    if (this.animal != null) {
      data['animal'] = this.animal.toJson();
    }
    return data;
  }
}
