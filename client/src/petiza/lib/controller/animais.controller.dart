import 'dart:convert';

import 'package:flutter/cupertino.dart';
import 'package:http/http.dart';
import 'package:mobx/mobx.dart';
import 'package:petiza/models/animais.model.dart';
import 'package:petiza/models/client.model.dart';
import 'package:shared_preferences/shared_preferences.dart';

abstract class _AnimaisController with Store {
  _AnimaisController() {
    cliente = null;
    token = null;
  }

  @observable
  Cliente cliente;

  @observable
  String token;
}
