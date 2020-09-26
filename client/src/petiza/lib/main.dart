import 'package:flutter/material.dart';
import 'package:flutter_tindercard/flutter_tindercard.dart';
import 'package:http/http.dart' as http;
import 'dart:async';
import 'dart:convert';

class API {
  static Future getAnimais() {
    return http.get('http://10.0.2.2:5042/api/Animal');
  }
}

Future<Animaizinhos> fetchAnimaizinhos() async {
  final response = await http.get('https://10.0.2.2:5042/api/Animal');

  if (response.statusCode == 200) {
    // If the server did return a 200 OK response,
    // then parse the JSON.
    return Animaizinhos.fromJson(json.decode(response.body));
  } else {
    // If the server did not return a 200 OK response,
    // then throw an exception.
    throw Exception('Failed to load Animaizinhos');
  }
}

class Animaizinhos {
  final String imageUrl;

  Animaizinhos({this.imageUrl});

  factory Animaizinhos.fromJson(Map<String, dynamic> json) {
    return Animaizinhos(imageUrl: json['imageUrl']);
  }
}

void main() => runApp(MyApp());

class MyApp extends StatelessWidget {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: ExampleHomePage(),
    );
  }
}

class ExampleHomePage extends StatefulWidget {
  @override
  _ExampleHomePageState createState() => _ExampleHomePageState();
}

class _ExampleHomePageState extends State<ExampleHomePage>
    with TickerProviderStateMixin {
  List<String> welcomeImages = ["images/welcome1.png", "images/welcome2.png"];
  var listAnimais = new List<Animaizinhos>();

  _getAnimais() {
    API.getAnimais().then((response) {
      setState(() {
        Iterable list = json.decode(response.body);
        listAnimais =
            list.map((model) => Animaizinhos.fromJson(model)).toList();
      });
    });
  }

  initState() {
    super.initState();
    _getAnimais();
  }

  dispose() {
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    CardController controller; //Use this to trigger swap.

    return new Scaffold(
      body: new Center(
        child: Container(
          height: MediaQuery.of(context).size.height * 0.6,
          child: new TinderSwapCard(
            swipeUp: true,
            swipeDown: true,
            orientation: AmassOrientation.BOTTOM,
            totalNum: listAnimais.length,
            stackNum: 2,
            swipeEdge: 4.0,
            maxWidth: MediaQuery.of(context).size.width * 0.9,
            maxHeight: MediaQuery.of(context).size.width * 0.9,
            minWidth: MediaQuery.of(context).size.width * 0.8,
            minHeight: MediaQuery.of(context).size.width * 0.8,
            cardBuilder: (context, index) => Card(
              child: Image.asset('${listAnimais[index].imageUrl}'),
            ),
            cardController: controller = CardController(),
            swipeUpdateCallback: (DragUpdateDetails details, Alignment align) {
              /// Get swiping card's alignment
              if (align.x < 0) {
                //Card is LEFT swiping
              } else if (align.x > 0) {
                //Card is RIGHT swiping
              }
            },
            swipeCompleteCallback:
                (CardSwipeOrientation orientation, int index) {
              /// Get orientation & index of swiped card!
            },
          ),
        ),
      ),
    );
  }
}
