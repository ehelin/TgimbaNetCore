function GetAvailableList() {
    var lists = GetLocalStorageLists();

    if (lists == null || lists == 'null') {
        lists = "CurrentVerbList,The Body,xmas2018List,MeetupList,Clothing,Colors,Family Members,Fruits,House Terms,Map Terms,Prepositions Misc,Questions,Shops,Time,Vegetables,VerbsAR,VerbsER,VerbsIR,Verbs2";
        SetLocalStorageLists(lists);
    }

    return lists;
}

function GetSelectedListContents(selectedList) {
    var list = null;

    if (selectedList == 'CurrentVerbList') {
        list = GetCurrentVerbList();
    }

    else if (selectedList == 'The Body')
        list = GetBodyParts();
    else if (selectedList == 'xmas2018List')
        list = GetXmas2018List();
    else if (selectedList == 'Clothing')
        list = GetClothing();
    else if (selectedList == 'Colors')
        list = GetColors();
    else if (selectedList == 'Family Members')
        list = GetFamilyMembers();
    else if (selectedList == 'Fruits')
        list = GetFruits();
    else if (selectedList == 'House Terms')
        list = GetHouseTerms();
    else if (selectedList == 'Map Terms')
        list = GetMapTerms();
    else if (selectedList == 'Prepositions Misc')
        list = GetPrepositions();
    else if (selectedList == 'Questions')
        list = GetQuestions();
    else if (selectedList == 'Shops')
        list = GetShops();

    else if (selectedList == 'MeetupList')
        list = GetMeetupList();

    else if (selectedList == 'Time')
        list = GetTimeWords();
    else if (selectedList == 'Vegetables')
        list = GetVegetables();

    else if (selectedList == 'VerbsAR')
        list = GetVerbsAR();

    else if (selectedList == 'VerbsER')
        list = GetVerbsER();

    else if (selectedList == 'VerbsIR')
        list = GetVerbsIR();

    else if (selectedList == 'Verbs2')
        list = GetVerbs2();

    if (list == null || list == 'null') {
        list = GetTargetList(selectedList);

        if (list != null) {
            var pos = list.indexOf(RIGHT_BRACKET);
            list = list.substring(pos + 1);
        }
    }

    return list;
}

//Start lists ---------------------------------------
//put this into lists
function GetPhrases() {
    var phrases = '';

    vegetables = "1,What does it mean?,Que quiere dicer?  ;";

}
function GetVegetables() {
    var vegetables = '';

    vegetables = "1,asparagus,el espárrago;";
    vegetables = vegetables + "2,avocado,el aguacate;";
    vegetables = vegetables + "3,bamboo shoots,los tallos de bambú;";
    vegetables = vegetables + "4,bean,el frijol;";
    vegetables = vegetables + "5,beet,la remolacha;";
    vegetables = vegetables + "6,bok choy,la col china;";
    vegetables = vegetables + "7,broccoli,el brócoli;";
    vegetables = vegetables + "8,Brussels sprout,col de Bruselas;";
    vegetables = vegetables + "9,cabbage,la col;";
    vegetables = vegetables + "10,carrot,la zanahoria;";
    vegetables = vegetables + "11,cassava,la yuca;";
    vegetables = vegetables + "12,cauliflower,la coriflor;";
    vegetables = vegetables + "13,celery,el apio;";
    vegetables = vegetables + "14,chard,la acelga;";
    vegetables = vegetables + "15,chicory,la achicoria;";
    vegetables = vegetables + "16,chickpea,el garbanzo;";
    vegetables = vegetables + "17,corn (American English),el maíz;";
    vegetables = vegetables + "18,cucumber,el pepino;";
    vegetables = vegetables + "19,eggplant,la berenjena;";
    vegetables = vegetables + "20,endive,la endivia;";
    vegetables = vegetables + "21,garlic,el ajo;";
    vegetables = vegetables + "22,ginger,el jengibre;";
    vegetables = vegetables + "23,green pepper,el pimiento verde;";
    vegetables = vegetables + "24,Jerusalem artichoke,el tupinambo;";
    vegetables = vegetables + "25,jicama,la jícama;";
    vegetables = vegetables + "26,leek,el puerro;";
    vegetables = vegetables + "27,lentil,la lenteja;";
    vegetables = vegetables + "28,rhubarb,el ruibarbo;";
    vegetables = vegetables + "29,lettuce,la lechuga;";
    vegetables = vegetables + "30,mushroom,el champiñón;";
    vegetables = vegetables + "31,okra,el quingombó;";
    vegetables = vegetables + "32,onion,la cebolla;";
    vegetables = vegetables + "33,parsley,el perejil;";
    vegetables = vegetables + "34,parsnip,la chirivía;";
    vegetables = vegetables + "35,pea,los guisantes;";
    vegetables = vegetables + "36,potato,la patata;";
    vegetables = vegetables + "37,pumpkin,la calabaza;";
    vegetables = vegetables + "38,radish,el rábano;";
    vegetables = vegetables + "39,red pepper,el pimiento rojo;";
    vegetables = vegetables + "40,rutabaga,el nabo sueco;";
    vegetables = vegetables + "41,shallot,el chalote;";
    vegetables = vegetables + "42,soybean,la semilla de soja;";
    vegetables = vegetables + "43,spinach,las espinacas;";
    vegetables = vegetables + "44,sorrel,la acedera;";
    vegetables = vegetables + "45,squash,la cucurbitácea;";
    vegetables = vegetables + "46,string beans,las habas verdes;";
    vegetables = vegetables + "47,sweet potato,la batata;";
    vegetables = vegetables + "48,tapioca,la tapioca;";
    vegetables = vegetables + "49,tomatillo,el tomatillo;";
    vegetables = vegetables + "50,tomato,el tomate;";
    vegetables = vegetables + "51,turnip,el nabo;";
    vegetables = vegetables + "52,water chestnut,la castaña de agua;";
    vegetables = vegetables + "53,watercress,el berro;";
    vegetables = vegetables + "54,yam,el boniato;";
    vegetables = vegetables + "55,zucchini,el calabacín;";

    return vegetables;
}
function GetShops() {
    var shops = '';

    shops = "1,coffeeshop,cafe;";
    shops = shopw + "2,butcher shop (from carne, meat),carnicería;";
    shops = shopw + "3,brewery,cervecería;";
    shops = shopw + "4,candy store,confitería;";
    shops = shopw + "5,oral surgeon's office,dentistería;";
    shops = shopw + "6,drugstore,droguería;";
    shops = shopw + "7,cabinet shop,ebanistería;";
    shops = shopw + "8,hardware store,ferretería;";
    shops = shopw + "9,flower shop,floristería;";
    shops = shopw + "10,fruit shop,frutería;";
    shops = shopw + "11,ice cream parlor,heladería;";
    shops = shopw + "12,herbalist's shop,herboristería;";
    shops = shopw + "13,blacksmith's shop,herrería;";
    shops = shopw + "14,jewelry shop,joyería;";
    shops = shopw + "15,toy shop,juguetería;";
    shops = shopw + "16,laundry clearner,lavandería;";
    shops = shopw + "17,dairy,lechería;";
    shops = shopw + "18,linen shop,lencería;";
    shops = shopw + "19,bookstore,librería;";
    shops = shopw + "20,furniture store,mueblería;";
    shops = shopw + "21,bakery,panadería;";
    shops = shopw + "22,stationery store,papelería;";
    shops = shopw + "23,pastry shop,pastelería;";
    shops = shopw + "24,beauty shop,peluquería;";
    shops = shopw + "25,seafood store,pescadería;";
    shops = shopw + "26,fragrance shop,perfumería;";
    shops = shopw + "27,pizza parlor,pizzería;";
    shops = shopw + "28,tailor's shop,sastrería;";
    shops = shopw + "29,hat shop,sombrerería;";
    shops = shopw + "30,furniture store,tapicería;";
    shops = shopw + "31,dry-cleaner's,tintotería;";
    shops = shopw + "32,produce store,verdulería;";
    shops = shopw + "33,shoe store,zapatería;";

    return shops;
}
function GetMeetupList() {
    var meetupList = '';

    meetupList = "1,el proximó viernes, next friday;";
    meetupList = meetupList + "2,el viernes pasado,last Friday;";
    meetupList = meetupList + "3,murciélago,bat;";
    meetupList = meetupList + "4,cuanto tiempo has estado aqui,how long have you been here;";
    meetupList = meetupList + "5,durante cuanto tiempo estuviste aqui,for how long were you here;";
    meetupList = meetupList + "6,subir, to go up;";
    meetupList = meetupList + "7,escalar, to climb;";
    meetupList = meetupList + "8,cola,end of the line;";
    meetupList = meetupList + "9,fila,line of people;";
    meetupList = meetupList + "10,chingo,alot(bad word);";	
    meetupList = meetupList + "11,banqueta,sidewalk;";
    meetupList = meetupList + "12,recursos de viviento,living resources;";
    meetupList = meetupList + "13,el cuarto mas viejo,the fourth oldest;";
    meetupList = meetupList + "14,banca,bank or long bench;";
    meetupList = meetupList + "15,banco,single stool;";
    meetupList = meetupList + "16,fecales,fecalvete a la mierda,fuck you;";
    meetupList = meetupList + "17,el culo,kiss my ass;";
    meetupList = meetupList + "18,cariño,sweetie;";
    meetupList = meetupList + "19,en México en todas partes,in mexico everywhere;";
    meetupList = meetupList + "20,Las Tijeras,the scissors;";
    meetupList = meetupList + "21,La campana,the bell;";
    meetupList = meetupList + "22,Las Fuentes,the fountains;";
    meetupList = meetupList + "23,Pluma,pen;";
    meetupList = meetupList + "24,La cadena,the chain;";
    meetupList = meetupList + "25,La revista,the magazine;";
    meetupList = meetupList + "26,El puente,the bridge;";
    meetupList = meetupList + "27,La pantalla,The picture;";
    meetupList = meetupList + "28,La bandera,the flag;";
    meetupList = meetupList + "29,los bancos,the benches;";
    meetupList = meetupList + "30,la coasta,the shore;";
    meetupList = meetupList + "31,la carcel,the prison;";
    meetupList = meetupList + "32,el calle, la calle jeros,street / road inside city;";
    meetupList = meetupList + "33,la carretera / el autopista,highway(road outside city);";
    meetupList = meetupList + "34,la camina,the walk;";
    meetupList = meetupList + "35,el hogar,the home;";
    meetupList = meetupList + "36,la avenida,the avenue;";
    meetupList = meetupList + "37,la esquina,the corner;";
    meetupList = meetupList + "38,las pistas,the clues;";
    meetupList = meetupList + "39,la ruta,the route;";
    meetupList = meetupList + "40,el dueño,the owner;";
    meetupList = meetupList + "41,desmadre,chaosave,birds;";
    meetupList = meetupList + "42,campo,countryside;";
    meetupList = meetupList + "43,disparar,to shoot;";
    meetupList = meetupList + "44,nunca falla,never fails;";
    meetupList = meetupList + "45,esposas de policia,police handcuffs;";
    meetupList = meetupList + "46,compartir,to share;";
    meetupList = meetupList + "47,domitorio / habitacion / recamara,bedroom;";
    meetupList = meetupList + "48,comerse eat it;";
    meetupList = meetupList + "49,un placer,a pleasure;";
    meetupList = meetupList + "50,aunque,even though / although;";
    meetupList = meetupList + "51,demasiado,too;";
    meetupList = meetupList + "52,cuidate,beware / watch out;";
    meetupList = meetupList + "53,orgullosa,proud;";
    meetupList = meetupList + "54,vaya,go;";
    meetupList = meetupList + "55,supuesto,supposed;";
    meetupList = meetupList + "56,a veces,sometimes;";
    meetupList = meetupList + "57,encojer,to shrink;";
    meetupList = meetupList + "58,el pasto / césped,grass;";
    meetupList = meetupList + "59,condado,county;";
    meetupList = meetupList + "60,palido - palepez,live fish;";
    meetupList = meetupList + "61,amargo / a,bitter;";
    meetupList = meetupList + "62,tirar,pull;";
    meetupList = meetupList + "63,empujar,pull???;";
    meetupList = meetupList + "64,tubo,pipe;";
    meetupList = meetupList + "65,prueba,to taste;";
    meetupList = meetupList + "66,aquel,some;";
    meetupList = meetupList + "67,aquellos,those;";
    meetupList = meetupList + "68,ningun  anyel arroyo,the creek;";
    meetupList = meetupList + "69,relámpagos,lighting bolts;";
    meetupList = meetupList + "70,ademas,besides;";
    meetupList = meetupList + "71,quizas,perhaps;";
    meetupList = meetupList + "72,perezoso,lazy;";
    meetupList = meetupList + "73,juzgar - to judgeoreja,ear;";
    meetupList = meetupList + "74,alrededor,around;";
    meetupList = meetupList + "75,jamás,never;";
    meetupList = meetupList + "76,barco,ship;";
    meetupList = meetupList + "77,mentis,lie;";
    meetupList = meetupList + "78,tengo sueño,i am sleepy;";
    meetupList = meetupList + "79,miseria,peanuts;";
    meetupList = meetupList + "80,modismo,idiom(its raining cats and dogs);";
    meetupList = meetupList + "81,puerco / cerdo,pig;";
    meetupList = meetupList + "82,culta,cultured / educated;";
    meetupList = meetupList + "83,exito,success;";
    meetupList = meetupList + "84,acordarse,to remember(reflexive);";
    meetupList = meetupList + "85,pues,well then;";
    meetupList = meetupList + "86,estadounidense,american;";
    meetupList = meetupList + "87,equipo,team;";
    meetupList = meetupList + "88,esencialmente,essentially;";
    meetupList = meetupList + "89,manteca,butter fat from milk;";
    meetupList = meetupList + "90,que no te caiga el chauhuistle;";
    meetupList = meetupList + "91,caijerse el chauhuistle,fungisel;";
    meetupList = meetupList + "92,tema,the theme;";
    meetupList = meetupList + "93,la cumbre,the top;";
    meetupList = meetupList + "94,señales,signals;";
    meetupList = meetupList + "95,flaquillo,skinny;";
    meetupList = meetupList + "96,flaco, skinny;";
    meetupList = meetupList + "97,flaquito, skinny;";
    meetupList = meetupList + "98,flaquillo,skinny;";
    meetupList = meetupList + "99,Flaco,skinny;";
    meetupList = meetupList + "100,Flaquito,little skinny;";
    meetupList = meetupList + "101,al rato,later;";
    meetupList = meetupList + "102,estas esperando;";
    meetupList = meetupList + "103,tu turno para la machina de refreshcos / bebitas;";			 
	meetupList = meetupList + "104,mostaza,mustard;"; 
	meetupList = meetupList + "105,no he pudido regresar,i have not returned;"; 
	meetupList = meetupList + "106,el gobierno,the government;"; 
	meetupList = meetupList + "107,gobernando,governing;"; 
	meetupList = meetupList + "108,yo he estado,i have been;"; 
	meetupList = meetupList + "109,yo he ido,i have gone;"; 
	meetupList = meetupList + "110,voz,you;"; 
	meetupList = meetupList + "111,tengo una galleta,i have a cookie;";
	meetupList = meetupList + "112,a todo partes,everywhere (to all parts);"; 
	meetupList = meetupList + "113,paradas continua,continouous stops;"; 
	meetupList = meetupList + "114,dejando el cuidad,leaving the city;"; 
	meetupList = meetupList + "115,mitad,half;"; 
	meetupList = meetupList + "116,asi corro,i run like this;"; 
	meetupList = meetupList + "117,chanka,sandal (mexico);"; 
	meetupList = meetupList + "118,contratando,hiring;"; 
	meetupList = meetupList + "119,nivel,level;"; 
	meetupList = meetupList + "120,compatir,to share;"; 
	meetupList = meetupList + "121,como lo estoy haciendo,how am i doing;"; 
	meetupList = meetupList + "122,me voy a banar,i am going to shower;"; 
	meetupList = meetupList + "123,entreviste,interview;"; 
	meetupList = meetupList + "124,maestro suplente,substitute teacher;";
	meetupList = meetupList + "125,estoy un soldado en el ejercito,i am a soldier in the army;";
	meetupList = meetupList + "126,nosotros jugamos básquetbol,we play basketball;"; 
	meetupList = meetupList + "127,güey,bull pulling plow...now means as deragatory;"; 
	meetupList = meetupList + "128,libre,free;";
	meetupList = meetupList + "130,totops,chips;";
	meetupList = meetupList + "131,lilli le gusta cariño mucho,lilli likes love a lot;";
	meetupList = meetupList + "132,elote,corn on the cob;"; 
	meetupList = meetupList + "133,paquete de programma,software (package of programs);"; 
	meetupList = meetupList + "134,voy a bañarme,i am going to shower;";

    return meetupList;
}
function GetColors() {
    var colors = '';

    colors = '1,red,rojo;';
    colors = colors + '2,pink,rosado;';
    colors = colors + '3,marron,marron;';
    colors = colors + '4,orange,naranja;';
    colors = colors + '5,blue,azul;';
    colors = colors + '6,green,verde;';
    colors = colors + '7,yellow,amarillo;';

    return colors;
}
function GetHouseTerms() {
    var houseTerms = '';

    houseTerms = "1,attic,el ático;";
    houseTerms = houseTerms + "2,basement,el sótano;";
    houseTerms = houseTerms + "3,bathroom,el baño;";
    houseTerms = houseTerms + "4,bedroom,el dormitorio;";
    houseTerms = houseTerms + "5,closet,el ropero;";
    houseTerms = houseTerms + "6,courtyard,el patio;";
    houseTerms = houseTerms + "7,den, study,el estudio;";
    houseTerms = houseTerms + "8,dining room,el comedor;";
    houseTerms = houseTerms + "9,entryway,la entrada;";
    houseTerms = houseTerms + "10,family room,la estancia;";
    houseTerms = houseTerms + "11,garage,el garage;";
    houseTerms = houseTerms + "12,kitchen,la cocina;";
    houseTerms = houseTerms + "13,living room,la sala de estar;";
    houseTerms = houseTerms + "14,room,el cuarto;";
    houseTerms = houseTerms + "15,ceiling,el techo;";
    houseTerms = houseTerms + "16,cupboard,el armario;";
    houseTerms = houseTerms + "17,door,la puerta;";
    houseTerms = houseTerms + "18,electrical socket,el enchufe (de pared);";
    houseTerms = houseTerms + "19,faucet,el grifo;";
    houseTerms = houseTerms + "20,floor,el suelo (floor that is walked on) or el piso (level of a building);";
    houseTerms = houseTerms + "21,(kitchen) counter,el mostrador (de cocina);";
    houseTerms = houseTerms + "22,lamp,la lámpara;";
    houseTerms = houseTerms + "23,light,la luz;";
    houseTerms = houseTerms + "24,mirror,el espejo;";
    houseTerms = houseTerms + "25,roof,el tejado;";
    houseTerms = houseTerms + "26,sink,el fregadero;";
    houseTerms = houseTerms + "27,stairs,la escalera;";
    houseTerms = houseTerms + "28,toilet,el váter;";
    houseTerms = houseTerms + "29,wall,la pared (inside) or el muro (outside);";
    houseTerms = houseTerms + "30,window,la ventana;";
    houseTerms = houseTerms + "31,bed,la cama;";
    houseTerms = houseTerms + "32,blender,la licuadora;";
    houseTerms = houseTerms + "33,chair,la silla;";
    houseTerms = houseTerms + "34,chest of drawers,la cómoda;";
    houseTerms = houseTerms + "35,couch,el sofá;";
    houseTerms = houseTerms + "36,dishwasher,el lavavajillas;";
    houseTerms = houseTerms + "37,drier (for clothes),la secadora;";
    houseTerms = houseTerms + "38,iron,la plancha;";
    houseTerms = houseTerms + "39,oven,el horno;";
    houseTerms = houseTerms + "40,stove,la estufa;";
    houseTerms = houseTerms + "41,vacuum cleaner,la aspiradora;";
    houseTerms = houseTerms + "42,table,la mesa;";
    houseTerms = houseTerms + "43,toaster,el tostador, la tostadora;";
    houseTerms = houseTerms + "44,washer (for clothes),la lavadora ;";

    return houseTerms;
}
function GetPrepositions() {
    var prepositions = '';

    prepositions = "1,to, at,a;";
    prepositions = prepositions + "2,before,antes de;";
    prepositions = prepositions + "3,about,acerca a;";
    prepositions = prepositions + "4,under,bajo;";
    prepositions = prepositions + "5,near,cerca de;";
    prepositions = prepositions + "6,with,con;";
    prepositions = prepositions + "7,against,contra;";
    prepositions = prepositions + "8,of or from,de;";
    prepositions = prepositions + "9,in front of,delante de;";
    prepositions = prepositions + "10,inside,dentro de;";
    prepositions = prepositions + "11,since or from,desde;";
    prepositions = prepositions + "12,after,después de;";
    prepositions = prepositions + "13,behind,detrás de;";
    prepositions = prepositions + "14,during,durante;";
    prepositions = prepositions + "15,in or on,en;";
    prepositions = prepositions + "16,on top of,encima de;";
    prepositions = prepositions + "17,in front of,enfrente de;";
    prepositions = prepositions + "18,between,entre;";
    prepositions = prepositions + "19,outside of,fuera de;";
    prepositions = prepositions + "20,toward,hacia;";
    prepositions = prepositions + "21,until,hasta;";
    prepositions = prepositions + "22,for or in order to,para;";
    prepositions = prepositions + "23,for or by,por;";
    prepositions = prepositions + "24,according to,según;";
    prepositions = prepositions + "25,without,sin;";
    prepositions = prepositions + "26,on or about,sobre;";
    prepositions = prepositions + "27,after or behind,tras;";
    prepositions = prepositions + "28,then,entonces;";
    prepositions = prepositions + "29,then,luego;";
    prepositions = prepositions + "30,each,cada;";
    prepositions = prepositions + "31,wow,orale;";
    prepositions = prepositions + "32,well then,pues;";
    prepositions = prepositions + "33,if (if no accent),si;";
    prepositions = prepositions + "34,already,ya;";
    prepositions = prepositions + "35,our,nuestro/a;";
    prepositions = prepositions + "36,fact,hecho;";
    prepositions = prepositions + "37,any,cualquier;";
    prepositions = prepositions + "38,never,nunca;";
    prepositions = prepositions + "39,older,mayor;";
    prepositions = prepositions + "40,here,acá;";
    prepositions = prepositions + "41,still,todavía;";
    prepositions = prepositions + "42,far away,lejos;";
    prepositions = prepositions + "43,together,junto;";
    prepositions = prepositions + "44,in,adentro;";
    prepositions = prepositions + "45,together,junto;";
    prepositions = prepositions + "46,lazy,flojo;";
    prepositions = prepositions + "47,rich,rico;";
    prepositions = prepositions + "48,so,tan;";
    prepositions = prepositions + "49,again,otra vez;";
    prepositions = prepositions + "50,picky,exigente;";
    prepositions = prepositions + "51,in loveenamorado;";
    prepositions = prepositions + "52,to build up (buzz),ya se armo (slang);";
    prepositions = prepositions + "53,anyone,cualquiera;";
    prepositions = prepositions + "54,well then,pues;";
    prepositions = prepositions + "55,already,ya;";
    prepositions = prepositions + "56,let,deje;";
    prepositions = prepositions + "57,game,juego;";
    prepositions = prepositions + "58,gift,regalo;";
    prepositions = prepositions + "59,some more,algo mas;";

    return prepositions;
}
function GetBodyParts() {
    var bodyparts = '';

    bodyparts = '1,arm,el brazo;';
    bodyparts = bodyparts + '2,back,la espalda;';
    bodyparts = bodyparts + '3,backbone,la columna vertebral;';
    bodyparts = bodyparts + '4,brain,el cerebro;';
    bodyparts = bodyparts + '5,chest,el pecho;';
    bodyparts = bodyparts + '6,buttocks,las nalgas;';
    bodyparts = bodyparts + '7,calf,la pantorrilla;';
    bodyparts = bodyparts + '8,ear,el oído;';
    bodyparts = bodyparts + '9,elbow,el codo;';
    bodyparts = bodyparts + '10,eye,el ojo;';
    bodyparts = bodyparts + '11,finger,el dedo;';
    bodyparts = bodyparts + '12,foot,el pie;';
    bodyparts = bodyparts + '13,hair,el pelo;';
    bodyparts = bodyparts + '14,hand,la mano;';
    bodyparts = bodyparts + '15,head,la cabeza;';
    bodyparts = bodyparts + '16,heart,el corazón;';
    bodyparts = bodyparts + '17,hip,la cadera;';
    bodyparts = bodyparts + '18,intestine,el intestino;';
    bodyparts = bodyparts + '19,knee,la rodilla;';
    bodyparts = bodyparts + '20,leg,la pierna;';
    bodyparts = bodyparts + '21,liver,el hígado;';
    bodyparts = bodyparts + '22,mouth,la boca;';
    bodyparts = bodyparts + '23,muscle,el músculo;';
    bodyparts = bodyparts + '24,neck,el cuello;';
    bodyparts = bodyparts + '25,nose,la nariz;';
    bodyparts = bodyparts + '26,shoulder,el hombro;';
    bodyparts = bodyparts + '27,skin,la piel;';
    bodyparts = bodyparts + '28,stomach (abdomen),el vientre;';
    bodyparts = bodyparts + '29,stomach (internal organ),el estómago;';
    bodyparts = bodyparts + '30,thigh,el muslo;';
    bodyparts = bodyparts + '31,throat,la garganta;';
    bodyparts = bodyparts + '32,toe,el dedo;';
    bodyparts = bodyparts + '33,tongue,la lengua;';
    bodyparts = bodyparts + '34,tooth,el diente;';

    return bodyparts;
}
function GetClothing() {
    var clothing = '';

    clothing = '1,bathrobe,el albornoz;';
    clothing = clothing + '2,belt,el cinturón;';
    clothing = clothing + '3,blouse,la blusa;';
    clothing = clothing + '4,boots,las botas;';
    clothing = clothing + '5,cap,la gorra;';
    clothing = clothing + '6,coat,el abrigo;';
    clothing = clothing + '7,dress,el vestido;';
    clothing = clothing + '8,gloves,los guantes;';
    clothing = clothing + '9,hat,el sombrero;';
    clothing = clothing + '10,jacket,la chaqueta;';
    clothing = clothing + '11,jeans,los jeans;';
    clothing = clothing + '12,miniskirt,la minifalda;';
    clothing = clothing + '13,pajamas,la pijama;';
    clothing = clothing + '14,pants,los pantalones;';
    clothing = clothing + '15,purse,el bolso;';
    clothing = clothing + '16,raincoat,el impermeable;';
    clothing = clothing + '17,sandal,la sandalia;';
    clothing = clothing + '18,shirt,la camisa;';
    clothing = clothing + '19,shoe,el zapato;';
    clothing = clothing + '20,shorts,los pantalones cortos;';
    clothing = clothing + '21,skirt,la falda;';
    clothing = clothing + '22,slipper,la zapatilla;';
    clothing = clothing + '23,sock,el calcetín;';
    clothing = clothing + '24,stocking,la media;';
    clothing = clothing + '25,suit,el traje;';
    clothing = clothing + '26,sweater,el suéter;';
    clothing = clothing + '27,sweatshirt,la sudadera;';
    clothing = clothing + '28,sweatsuit,el traje de entrenamiento;';
    clothing = clothing + '29,swimsuit,el bañador;';
    clothing = clothing + '30,tennis shoe, sneaker,el zapato de tenis;';
    clothing = clothing + '31,tie,la corbata;';
    clothing = clothing + '32,T-shirt,la camiseta;';
    clothing = clothing + '33,underwear,la ropa interior;';
    clothing = clothing + '34,wristwatch,el reloj;';

    return clothing;
}
function GetTimeWords() {
    var timeWords = '';

    timeWords = "1,Monday,lunes;";
    timeWords = timeWords + "2,Tuesday,martes;";
    timeWords = timeWords + "3,Wednesday,miercoles;";
    timeWords = timeWords + "4,Thursday,jueves;";
    timeWords = timeWords + "5,Friday,viernes;";
    timeWords = timeWords + "6,Saturday,sabado;";
    timeWords = timeWords + "7,Sunday,domingo;";
    timeWords = timeWords + "8,January,enero;";
    timeWords = timeWords + "9,Feburary,febrero;";
    timeWords = timeWords + "10,March,marcha;";
    timeWords = timeWords + "11,April,abril;";
    timeWords = timeWords + "12,May,mayo;";
    timeWords = timeWords + "13,June,junio;";
    timeWords = timeWords + "14,July,julio;";
    timeWords = timeWords + "15,August,agosto;";
    timeWords = timeWords + "16,September,septiembre;";
    timeWords = timeWords + "17,October,octubre;";
    timeWords = timeWords + "18,November,noviembre;";
    timeWords = timeWords + "19,December, diciembre;";
    timeWords = timeWords + "20,in the morning (no specific time),por la mañana;";
    timeWords = timeWords + "21,in the morning (specific time),de la mañana;";
    timeWords = timeWords + "22,in the afternoon (no specific time),por la tarde;";
    timeWords = timeWords + "23,in the afternoon (specific time),de la tarde;";
    timeWords = timeWords + "24,in the evening or night (no specific time),por la noche;";
    timeWords = timeWords + "25,in the evening or night (specific time),de la noche;";
    timeWords = timeWords + "26,morning,la mañana;";
    timeWords = timeWords + "27,early,temprano;";
    timeWords = timeWords + "28,tomorrow morning,mañana por la mañana;";
    timeWords = timeWords + "29,the day after tomorrow,pasado mañana;";
    timeWords = timeWords + "30,yesterday,ayer;";
    timeWords = timeWords + "31,last night,anoche;";
    timeWords = timeWords + "32,the night before last,la noche anterior, anteanoche;";
    timeWords = timeWords + "33,next Monday,vel lunes que viene;";
    timeWords = timeWords + "34,next week,la semana que viene;";
    timeWords = timeWords + "35,next year,el año que viene;";
    timeWords = timeWords + "36,last Monday,el lunes pasado;";
    timeWords = timeWords + "37,last weekla semana pasada;";
    timeWords = timeWords + "38,last year,el año pasado;";
    timeWords = timeWords + "39,at noon,al medio día;";
    timeWords = timeWords + "40,at midnight,a la media noche;";
    timeWords = timeWords + "41,around,alrededor de;";
    timeWords = timeWords + "42,days,de días;";
    timeWords = timeWords + "43,during the day, durante el día;";
    timeWords = timeWords + "44,on time,a tiempo;";
    timeWords = timeWords + "45,exactly,en punto;";
    timeWords = timeWords + "46,late,tarde;";


    return timeWords;
}
function GetFamilyMembers() {
    var familyMembers = '';

    familyMembers = "1,father,padre;";
    familyMembers = familyMembers + "2,mother,madre;";
    familyMembers = familyMembers + "3,brother,hermano;";
    familyMembers = familyMembers + "4,sister,hermana;";
    familyMembers = familyMembers + "5,father-in-law,suegro;";
    familyMembers = familyMembers + "6,mother-in-law,suegra;";
    familyMembers = familyMembers + "7,brother-in-law,cuñado;";
    familyMembers = familyMembers + "8,sister-in-law,cuñada;";
    familyMembers = familyMembers + "9,husband,esposo or marido;";
    familyMembers = familyMembers + "10,wife,esposa or mujer;";
    familyMembers = familyMembers + "11,grandfather,abuelo;";
    familyMembers = familyMembers + "12,grandmother,abuela;";
    familyMembers = familyMembers + "13,son,hijo;";
    familyMembers = familyMembers + "14,daughter,hija;";
    familyMembers = familyMembers + "15,grandson,nieto;";
    familyMembers = familyMembers + "16,granddaughter,nieta;";
    familyMembers = familyMembers + "17,uncle,tío;";
    familyMembers = familyMembers + "18,aunt,tía;";
    familyMembers = familyMembers + "19,cousin (male),primo;";
    familyMembers = familyMembers + "20,cousin (female),prima;";
    familyMembers = familyMembers + "21,nephew,sobrino;";
    familyMembers = familyMembers + "22,niece,sobrina;";
    familyMembers = familyMembers + "23,stepfather,padrastro;";
    familyMembers = familyMembers + "24,stepmother,madrastra;";
    familyMembers = familyMembers + "25,stepson,hijastro;";
    familyMembers = familyMembers + "26,stepdaughter,hijastra;";
    familyMembers = familyMembers + "27,stepbrother,hermanastro;";
    familyMembers = familyMembers + "28,stepsister,hermanastra;";
    familyMembers = familyMembers + "29,male partner in a couple relationship,compañero;";
    familyMembers = familyMembers + "30,female partner in a couple relationship,compañera;";
    familyMembers = familyMembers + "31,godfather,padrino;";
    familyMembers = familyMembers + "32,godmother,madrina;";
    familyMembers = familyMembers + "33,godson,ahijado;";
    familyMembers = familyMembers + "34,goddaughter,ahijada;";
    familyMembers = familyMembers + "35,friend (male),amigo;";
    familyMembers = familyMembers + "36,friend (female),amiga;";

    return familyMembers;
}
function GetFruits() {
    var fruits = '';

    fruits = "1,apple,la manzana;";
    fruits = fruits + "2,apricot,el damasco, el albericoque;";
    fruits = fruits + "3,avocado,el aguacate;";
    fruits = fruits + "4,banana,el plátano, la banana;";
    fruits = fruits + "5,blackberry,la mora, la zarzamora;";
    fruits = fruits + "6,blueberry,el arándano;";
    fruits = fruits + "7,camu camu,el camu camu;";
    fruits = fruits + "8,cantaloupe,el cantalupo;";
    fruits = fruits + "9,cherimoya,la chirimoya;";
    fruits = fruits + "10,cherry,la cereza;";
    fruits = fruits + "11,coconut,el coco;";
    fruits = fruits + "12,cranberry,el arándano;";
    fruits = fruits + "13,date,el dátil;";
    fruits = fruits + "14,fig,el higo;";
    fruits = fruits + "15,galia,el melón galia;";
    fruits = fruits + "16,gooseberry,la grosella espinosa;";
    fruits = fruits + "17,grape,la uva;";
    fruits = fruits + "18,grapefruit,el pomelo, la toronja;";
    fruits = fruits + "19,guarana,la fruta de guaraná;";
    fruits = fruits + "20,huckleberry,el arándano;";
    fruits = fruits + "21,kiwi,el kiwi;";
    fruits = fruits + "22,kumquat,el kinoto;";
    fruits = fruits + "23,lemon,el limón;";
    fruits = fruits + "24,lime,la lima;";
    fruits = fruits + "25,loganberry,la zarza, la frambuesa;";
    fruits = fruits + "26,mandarin,la mandarina;";
    fruits = fruits + "27,mango,el mango;";
    fruits = fruits + "28,melón,el melón;";
    fruits = fruits + "29,mulberry,la mora;";
    fruits = fruits + "30,naranjilla,la naranjilla, el lulo;";
    fruits = fruits + "31,nectarine,la nectarina;";
    fruits = fruits + "32,orange,la naranja;";
    fruits = fruits + "33,papaya,la papaya;";
    fruits = fruits + "34,peach,el durazno, el melocotón;";
    fruits = fruits + "35,pear,la pera;";
    fruits = fruits + "36,persimmon,el caqui;";
    fruits = fruits + "37,pineapple,la piña, el ananá;";
    fruits = fruits + "38,plantain,el plátano;";
    fruits = fruits + "39,banana,la platanera;";
    fruits = fruits + "40,plum,la ciruela;";
    fruits = fruits + "41,pomegranate,la granada;";
    fruits = fruits + "42,prickly pear,la tuna, el higo chumbo;";
    fruits = fruits + "43,raspberry,la frambuesa;";
    fruits = fruits + "44,strawberry,la fresa, la frutilla;";
    fruits = fruits + "45,tangerine,la mandarina;";
    fruits = fruits + "46,tomatillo,el tomatillo;";
    fruits = fruits + "47,tomato,el tomate;";
    fruits = fruits + "48,watermelon,la sandía;";

    return fruits;
}
function GetQuestions() {
    var questions = '';

    questions = "1,why?,por que?;";
    questions = questions + "2,because,porque;";
    questions = questions + "3,what?,Cual/cuales? or que?;";
    questions = questions + "4,how much?,cuanto?;";
    questions = questions + "5,when?,cuando?;";
    questions = questions + "6,who?,Quien/quienes?;";
    questions = questions + "7,where?,donde?;";
    questions = questions + "8,to where?,Adonde?;";
    questions = questions + "9,how?,como?;";

    return questions;
}
function GetMapTerms() {
    var mapTerms = '';

    mapTerms = "1,highway,autopista;";
    mapTerms = mapTerms + "2,north,el norte;";
    mapTerms = mapTerms + "3,south,el sur;";
    mapTerms = mapTerms + "4,west,el oeste;";
    mapTerms = mapTerms + "5,east,el este;";
    mapTerms = mapTerms + "6,altitude,altitud;";
    mapTerms = mapTerms + "7,atlas,atlas;";
    mapTerms = mapTerms + "8,border,frontera;";
    mapTerms = mapTerms + "9,capital,capital;";
    mapTerms = mapTerms + "10,continent,continente;";
    mapTerms = mapTerms + "11,coordinates,coordenadas;";
    mapTerms = mapTerms + "12,equator,ecuador;";
    mapTerms = mapTerms + "13,hemisphere,hemisferio;";
    mapTerms = mapTerms + "14,key,teclado or clave;";
    mapTerms = mapTerms + "15,landmark,marca;";
    mapTerms = mapTerms + "16,latitude,latitud;";
    mapTerms = mapTerms + "17,longitude,longitud;";
    mapTerms = mapTerms + "18,prime meridian,primer meridiano;";
    mapTerms = mapTerms + "19,symbol,símbolo;";
    mapTerms = mapTerms + "20,time zone,zona horaria;";
    mapTerms = mapTerms + "21,avenue (Ave.),avenida;";
    mapTerms = mapTerms + "22,boulevard (Blvd.),bulevar;";
    mapTerms = mapTerms + "23,drive (Dr.) (noun),drive;";
    mapTerms = mapTerms + "24,east (E.),este;";
    mapTerms = mapTerms + "25,highway (Hwy.),carretera;";
    mapTerms = mapTerms + "26,mountain (Mt.),montaña;";
    mapTerms = mapTerms + "27,north (N.),norte;";
    mapTerms = mapTerms + "28,northeast (NE),noreste;";
    mapTerms = mapTerms + "29,road (Rd.),camino;";
    mapTerms = mapTerms + "30,railroad (RR),ferrocarril;";
    mapTerms = mapTerms + "31,route (Rt.),ruta;";
    mapTerms = mapTerms + "32,south (S.),sur;";
    mapTerms = mapTerms + "33,southeast (SE),sudeste;";
    mapTerms = mapTerms + "34,street (St.),calle;";
    mapTerms = mapTerms + "35,southwest (SW),suroeste;";
    mapTerms = mapTerms + "36,west (W.),oeste;";
    mapTerms = mapTerms + "37,cardinal directions,puntos cardinales;";

    return mapTerms;
}
function GetVerbsAR() {
    var verbs = "1,"
        + " to rent,"
        + " alquilar;"

        + "2,"
        + " to disturb,"
        + " disturbar;"

        + "3,"
        + " to love ,"
        + " amar;"

        + "4,"
        + " to assemble,"
        + " armar;"

        + "5,"
        + " to walk,"
        + " andar"
        + "<br/>Indicative_Preterite: anduve anduviste anduvo anduvimos anduvieron "
        + "<br/>Indicative_Imperfect: andaba andabas andaba andábamos andaban "
        + "<br/>Indicative_Present: ando andas anda andamos andan "
        + "<br/>Indicative_Future: andaré andarás andará andaremos andarán;"

        + "6,"
        + " to enroll,"
        + " anotar;"

        + "7,"
        + " to turn off,"
        + " apagar"
        + "<br/>Indicative_Preterite: apague apagaste apagó apagamos apagaron "
        + "<br/>Indicative_Imperfect: apagaba apagabas apagaba apagábamos apagaban "
        + "<br/>Indicative_Present: apague apagas apaga apagamos apagan "
        + "<br/>Indicative_Future: apagaré apagarás apagará apagaremos apagarán;"

        + "8,"
        + " to accept,"
        + " aceptar;"

        + "9,"
        + " to have lunch,"
        + " almorzar"
        + "<br/>Indicative_Preterite: almorcé almorzaste almorzó almorzamos almorzaron "
        + "<br/>Indicative_Imperfect: almorzaba almorzabas almorzaba almorzábamos almorzaban "
        + "<br/>Indicative_Present: almuerzo almuerzas almuerza almorzamos almuerzan "
        + "<br/>Indicative_Future: almorzaré almorzarás almorzará almorzaremos almorzarán;"

        + "10,"
        + " to catch,"
        + " atrapar;"

        + "11,"
        + "to adopt,"
        + "adoptar;"

        + "12,"
        + "to help,"
        + "ayudar;"

        + "13,"
        + "to bath,"
        + "bañar;"

        + "14,"
        + "to dance,"
        + "bailar;"

        + "15,"
        + "to go down,"
        + "bajar;"

        + "16,"
        + "to search,"
        + "buscar;"

        + "17,"
        + "to walk ,"
        + "caminar;"

        + "18,"
        + "to change,"
        + "cambiar;"

        + "19,"
        + "to cause,"
        + "causar;"

        + "20,"
        + "to cancel,"
        + "cancelar;"

        + "21,"
        + "to sing,"
        + "cantar;"																	

        + "22,"
        + "to have dinner,"
        + "cenar;"																	 

        + "23,"
        + "to close,"
        + "cerrar"
        + "<br/>Indicative_Preterite: cerré cerraste cerro cerramos cerraron "
        + "<br/>Indicative_Imperfect: cerraba cerrabas cerraba cerrábamos cerraban "
        + "<br/>Indicative_Present: cierro cierras cierra cerramos cierran "
        + "<br/>Indicative_Future: cerraré cerrarás cerrará cerraremos cerrarán ;"

        + "24,"
        + "to chat/talk,"
        + "charlar;"

        + "25,"
        + "to cook,"
        + "cocinar;"

        + "26,"
        + "to buy,"
        + "comprar;"																	  

        + "27,"
        + "to put/place,"
        + "colocar;"

        + "28,"
        + "to count,"
        + "contar"
        + "<br/>Indicative_Preterite: conté contaste contó contamos contaron "
        + "<br/>Indicative_Imperfect: contaba contabas contaba contábamos contaban "
        + "<br/>Indicative_Present: cuento cuentas cuenta contamos cuentan "
        + "<br/>Indicative_Future: contaré contarás contará contaremos contarán;"

        + "29,"
        + "to talk,"
        + "conversar;"																					  

        + "30,"
        + "to consider,"
        + "considerar;"																								   

        + "31,"
        + "to answer,"
        + "contestar;"																				  

        + "32,"
        + "to start,"
        + "comenzar"
        + "<br/>Indicative_Preterite: comencé comenzaste comenzó comenzamos comenzaron "
        + "<br/>Indicative_Imperfect: comenzaba comenzabas comenzaba comenzábamos comenzaban "
        + "<br/>Indicative_Present: comienzo comienzas comienza comenzamos comienzan "
        + "<br/>Indicative_Future: comenzaré comenzarás comenzará comenzaremos comenzarán;"

        + "33,"
        + "to cost,"
        + "costar"
        + "<br/>Indicative_Preterite: costé costaste constó constamos constaron "
        + "<br/>Indicative_Imperfect: costaba costabas costaba costábamos costaban "
        + "<br/>Indicative_Present: cuesto cuestas cuesta costamos cuestan "
        + "<br/>Indicative_Future: costaré costarás costará costaremos costarán;"

        + "34,"
        + "to cut,"
        + "cortar;"

        + "35,"
        + "to create,"
        + "crear;"

        + "36,"
        + "to give,"
        + "dar"
        + "<br/>Indicative_Preterite: dí diste dió dimos dieron "
        + "<br/>Indicative_Imperfect: daba dabas daba dábamos daban "
        + "<br/>Indicative_Present: doy das da damos dan "
        + "<br/>Indicative_Future: daré darás dará daramos darán;"

        + "37,"
        + "to allow,"
        + "dejar;"

        + "38,"
        + "to spell,"
        + "deletrear;"

        + "39,"
        + "to wake up,"
        + "despertar"
        + "<br/>Indicative_Preterite: desperté despertaste despertó despertamos despertaron "
        + "<br/>Indicative_Imperfect: despertaba despertabas despertaba despertábamos despertaban "
        + "<br/>Indicative_Present: despierto despiertas despierta despertamos despiertan "
        + "<br/>Indicative_Future: despertaré despertarás despertará despertaremos despertarán;"

        + "40,"
        + "to emphasize,"
        + "destacar;"

        + "41,"
        + "to enjoy,"
        + "disfrutar;"

        + "42,"
        + "to rest,"
        + "descansar;"

        + "43,"
        + "to have breakfast,"
        + "desayunar;"

        + "44,"
        + "to wish,"
        + "desear;"

        + "45,"
        + "to draw,"
        + "dibujar;"

        + "46,"
        + "to praise,"
        + "elevar;"

        + "47,"
        + "to climb,"
        + "escalar;"

        + "48,"
        + "to be sick,"
        + "enfermar;"

        + "49,"
        + "to enter,"
        + "entrar;"

        + "50,"
        + "to send,"
        + "enviar;"

        + "51,"
        + "to start,"
        + "empezar"
        + "<br/>Indicative_Preterite: empecé empezaste empezó empezamos empezaron "
        + "<br/>Indicative_Imperfect: empezaba empezabas empezaba empezábamos empezaban "
        + "<br/>Indicative_Present: empiezo empiezas empieza empezamos empiezan "
        + "<br/>Indicative_Future: empezaré empezarás empezará empezaremos empezarán;"

        + "52,"
        + "to listen to,"
        + "escuchar;"

        + "53,"
        + "to teach,"
        + "enseñar;"

        + "54,"
        + "to find,"
        + "encontrar"
        + "<br/>Indicative_Preterite: encontré encontraste encontró encontramos encontraron "
        + "<br/>Indicative_Imperfect: encontraba encontrabas encontraba encontrábamos encontraban "
        + "<br/>Indicative_Present: encuentro encuentras encuentra encontramos encuentran "
        + "<br/>Indicative_Future: encontraré encontrarás encontrará encontraremos encontrarán;"

        + "55,"
        + "to upset,"
        + "enojar;"

        + "56,"
        + "to hope,"
        + "esperar;"

        + "57,"
        + "to study,"
        + "estudiar;"

        + "58,"
        + "to be,"
        + "estar"
        + "<br/>Indicative_Preterite: estuve estuviste estuvo estuvimos estuvieron "
        + "<br/>Indicative_Imperfect: estaba estabas estaba estábamos estaban "
        + "<br/>Indicative_Present: estoy estas esta estamos estan "
        + "<br/>Indicative_Future: estaré estarás estará estaremos estarán;"

        + "59,"
        + "to miss,"
        + "extrañar;"

        + "60,"
        + "to explain,"
        + "explicar;"

        + "61,"
        + "to sign,"
        + "firmar;"

        + "62,"
        + "to finish,"
        + "finalizar;"

        + "63,"
        + "to smoke,"
        + "fumar;"

        + "64,"
        + "to win,"
        + "ganar;"

        + "65,"
        + "to spend money,"
        + "gastar;"

        + "66,"
        + "to like,"
        + "gustar;"

        + "67,"
        + "to talk,"
        + "hablar;"

        + "68,"
        + "to motivate,"
        + "impulsar;"

        + "69,"
        + "to try,"
        + "intentar;"

        + "70,"
        + "to insinuate/hint,"
        + "insinuar;"

        + "71,"
        + "to start,"
        + "iniciar;"

        + "72,"
        + "to play a game,"
        + "jugar"
        + "<br/>Indicative_Preterite: jugué jugaste jugó jugamos jugaron "
        + "<br/>Indicative_Imperfect: jugaba jugabas jugaba jugábamos jugaban "
        + "<br/>Indicative_Present: juego juegas juega jugamos juegan "
        + "<br/>Indicative_Future: jugaré jugarás jugará jugaremos jugarán;"

        + "73,"
        + "to wash ,"
        + "lavar;"

        + "74,"
        + "to call,"
        + "llamar;"

        + "75,"
        + "to clean,"
        + "limpiar;"

        + "76,"
        + "to arrive,"
        + "llegar;"

        + "77,"
        + "to fill,"
        + "llenar;"																	 

        + "78,"
        + "to wear to carry ,"
        + "llevar;"

        + "79,"
        + "to achieve,"
        + "lograr;"

        + "80,"
        + "to order ,"
        + "mandar;"

        + "81,"
        + "to dwell,"
        + "morar;"

        + "82,"
        + "to show ,"
        + "mostrar"
        + "<br/>Indicative_Preterite: mostré mostraste mostró mostramos mostraron "
        + "<br/>Indicative_Imperfect: mostraba mostrabas mostraba mostrábamos mostraban "
        + "<br/>Indicative_Present: muestro muestras muestra mostramos muestran "
        + "<br/>Indicative_Future: mostraré mostrarás mostrará mostraremos mostrarán;"

        + "83,"
        + "to watch look at ,"
        + "mirar;"

        + "84,"
        + "to snow,"
        + "nevar"
        + "<br/>Indicative_Preterite: nevé nevaste nevó nevamos nevaron "
        + "<br/>Indicative_Imperfect: nevaba nevabas nevaba nevábamos nevaban "
        + "<br/>Indicative_Present: nievo nievas nieva nevamos nievan "
        + "<br/>Indicative_Future: nevaré nevarás nevará nevaremos nevarán;"

        + "85,"
        + "to need ,"
        + "necesitar;"

        + "86,"
        + "to swim,"
        + "nadar;"

        + "87,"
        + "to forget,"
        + "olvidar;"

        + "88,"
        + "to organize,"
        + "organizar;"

        + "89,"
        + "to comb,"
        + "peinar;"

        + "90,"
        + "to pay for,"
        + "pagar;"

        + "91,"
        + "to practice,"
        + "practicar;"																				   

        + "92,"
        + "to ask for,"
        + "preguntar;"

        + "93,"
        + "to press,"
        + "presionar;"

        + "94,"
        + "to speak,"
        + "platicar;"

        + "95,"
        + "to prepare,"
        + "preparar;"

        + "96,"
        + "to think ,"
        + "pensar"
        + "<br/>Indicative_Preterite: pensé pensaste penso pensamos pensaron "
        + "<br/>Indicative_Imperfect: pensaba pensabas pensaba pensábamos pensaban "
        + "<br/>Indicative_Present: pienso piensas piensa pensamos piensan "
        + "<br/>Indicative_Future: pensaré pensarás pensará pensaremos pensarán;"

        + "97,"
        + "to pronounce,"
        + "pronunciar;"

        + "98,"
        + "to borrow,"
        + "prestar;"

        + "99,"
        + "to pass,"
        + "pasar;"

        + "100,"
        + "to remove ,"
        + "quitar;"

        + "101,"
        + "to give,"
        + "regalar;"

        + "102,"
        + "to return,"
        + "regresar;"

        + "103,"
        + "to fix,"
        + "reparar;"																	  

        + "104,"
        + "to remember,"
        + "recordar"
        + "<br/>Indicative_Preterite: recordé recordaste recordó recordamos recordaron "
        + "<br/>Indicative_Imperfect: recordaba recordabas recordaba recordábamos recordaban "
        + "<br/>Indicative_Present: recuerdo recuerdas recuerda recordamos recuerdan "
        + "<br/>Indicative_Future: recordaré recordarás recordará recordaremos recordarán;"

        + "105,"
        + "to greet,"
        + "saludar;"

        + "106,"
        + "to sit,"
        + "sentar"
        + "<br/>Indicative_Preterite: senté sentaste sentó sentamos sentaron "
        + "<br/>Indicative_Imperfect: sentaba sentabas sentaba sentábamos sentaban "
        + "<br/>Indicative_Present: siento sientes siente sentamos sientan "
        + "<br/>Indicative_Future: sentaré sentarás sentará sentaremos sentarán;"

        + "107,"
        + "to dream,"
        + "soñar"
        + "<br/>Indicative_Preterite: soñé soñaste soñó soñamos soñaron "
        + "<br/>Indicative_Imperfect: soñaba soñabas soñaba soñábamos soñaban "
        + "<br/>Indicative_Present: sueño sueñas sueña soñamos sueñan "
        + "<br/>Indicative_Future: soñaré soñarás soñará soñaremos soñarán;"

        + "108,"
        + "to touch play (an instrument),"
        + "tocar;"

        + "109,"
        + "to take drink,"
        + "tomar;"

        + "110,"
        + "to finish,"
        + "terminar;"

        + "111,"
        + "to work,"
        + "trabajar;"

        + "112,"
        + "to pull,"
        + "tirar;"

        + "113,"
        + "to treat,"
        + "tratar;"

        + "114,"
        + "to use,"
        + "utilizar;"

        + "115,"
        + "to use,"
        + "usar;"

        + "116,"
        + "to travel,"
        + "viajar;"

        + "117,"
        + "to visit,"
        + "visitar;"

        + "118,"
        + "to fly,"
        + "volar"
        + "<br/>Indicative_Preterite: volé volaste voló volamos volaron "
        + "<br/>Indicative_Imperfect: volaba volabas volaba volábamos volaban "
        + "<br/>Indicative_Present: vuelo vuelas vuela volamos vuelan "
        + "<br/>Indicative_Future: volaré volarás volará volaremos volarán;";

    return verbs;
}
function GetVerbsER() {
    var verbs = "1,"
        + "to learn,"
        + "aprender;"

        + "2,"
        + "to appear,"
        + "aparecer"
        + "<br/>Indicative_Preterite: aparecí aparenciste apareció aparencimos aparencieron "
        + "<br/>Indicative_Imperfect: aparencia aparencias aparencia aparencíamos aparencian "
        + "<br/>Indicative_Present: aparezco apareces aparece aparecemos aparecen "
        + "<br/>Indicative_Future: apareceré aparecerás aparecerá apareceremos aparencerán;"

        + "3,"
        + "to drink,"
        + "beber;"

        + "4,"
        + "to fit,"
        + "caber"
        + "<br/>Indicative_Preterite: cupe cupiste cupo cupimos cupieron "
        + "<br/>Indicative_Imperfect: cabia cabias cabia cabíamos cabian "
        + "<br/>Indicative_Present: quepo cabes cabe cabemos caben "
        + "<br/>Indicative_Future: cabré cabrás cabrá cabremos cabrán;"

        + "5,"
        + "to meet,"
        + "conocer"
        + "<br/>Indicative_Preterite: conocí conociste conoció conocimos conocieron "
        + "<br/>Indicative_Imperfect: conocia conocias conocia conocíamos conocian "
        + "<br/>Indicative_Present: conozco conoces conoce conocemos conocen "
        + "<br/>Indicative_Future: conoceré conocerás conocerá conoceremos conocerán;"

        + "6,"
        + "to eat,"
        + "comer;"

        + "7,"
        + "to understand,"
        + "comprender;"

        + "8,"
        + "to run,"
        + "correr;"																	  

        + "9,"
        + "to believe,"
        + "creer;"																 

        + "10,"
        + "to hurt, "
        + "doler"
        + "<br/>Indicative_Preterite: dolí doliste dolió dolimos dolieron "
        + "<br/>Indicative_Imperfect: dolia dolias dolia dolíamos dolian "
        + "<br/>Indicative_Present: duelo dueles duele dolemos duelen "
        + "<br/>Indicative_Future: doleré dolerás dolerá doleremos dolerán;"

        + "11,"
        + "to owe,"
        + "deber;"

        + "12,"
        + "to hide,"
        + "esconder;"

        + "13,"
        + "to turn on,"
        + "encender"
        + "<br/>Indicative_Preterite: encendí encendiste encendió encendimos encendieron "
        + "<br/>Indicative_Imperfect: encendia encendias encendia encendíamos encendian "
        + "<br/>Indicative_Present: enciendo enciendes enciende encendemos encienden "
        + "<br/>Indicative_Future: encenderé encenderás encenderá encenderemos encenderán;"

        + "14,"
        + "to understand,"
        + "entender"
        + "<br/>Indicative_Preterite: entendí entendiste entendió entendimos entendieron "
        + "<br/>Indicative_Imperfect: entendia entendias entendia entendíamos entendian "
        + "<br/>Indicative_Present: entiendo entiendes entiende entendemos entienden "
        + "<br/>Indicative_Future: entenderé entenderás entenderá entenderemos entenderán;"

        + "15,"
        + "to have,"
        + "haber"
        + "<br/>Indicative_Preterite: hube hubiste hubo hubimos hubieron "
        + "<br/>Indicative_Imperfect: habia habias habia habíamos habian "
        + "<br/>Indicative_Present: he has ha/hay hemos han "
        + "<br/>Indicative_Future: habré habrás habrá habremos habrán;"

        + "16,"
        + "to make,"
        + "hacer"
        + "<br/>Indicative_Preterite: hice hiciste hizo hicimos hicieron "
        + "<br/>Indicative_Imperfect: hacia hacias hacia hacíamos hacian "
        + "<br/>Indicative_Present: hago haces hace hacemos hacen "
        + "<br/>Indicative_Future: haré harás hará haremos harán;"

        + "17,"
        + "to rain,"
        + "llover"
        + "<br/>Indicative_Preterite: lloví lloviste llovió llovimos llovieron "
        + "<br/>Indicative_Imperfect: llovia llovias llovia llovíamos llovian "
        + "<br/>Indicative_Present: lluevo llueves llueve llovemos llueven "
        + "<br/>Indicative_Future: lloveré lloverás lloverá lloveremos lloverán;"

        + "18,"
        + "to read,"
        + "leer;"

        + "19,"
        + "to put,"
        + "meter;"

        + "20,"
        + "to move,"
        + "mover"
        + "<br/>Indicative_Preterite: moví moviste movió movimos movieron "
        + "<br/>Indicative_Imperfect: movia movias movia movíamos movian "
        + "<br/>Indicative_Present: muevo mueves mueve movemos mueven "
        + "<br/>Indicative_Future: moveré moverás moverá moveremos moverán;"

        + "21,"
        + "to offer,"
        + "ofrecer"
        + "<br/>Indicative_Preterite: ofrecí  ofreciste ofreció ofrecimos ofrecieron "
        + "<br/>Indicative_Imperfect: ofrecia ofrecias ofrecia ofrecíamos ofrecian "
        + "<br/>Indicative_Present: ofrezco ofreces ofrece ofrecemos ofrecen "
        + "<br/>Indicative_Future: ofreceré ofrecerás ofrecerá ofreceremos ofrecerán;"

        + "22,"
        + "to seem,"
        + "parecer"
        + "<br/>Indicative_Preterite: parecí  pareciste pareció parecimos paricieron "
        + "<br/>Indicative_Imperfect: parecia parecias parecia parecíamos parecian "
        + "<br/>Indicative_Present: parezco pareces parece parecemos parecen "
        + "<br/>Indicative_Future: pareceré parecerás parecerá pareceremos parecerán;"

        + "23,"
        + "to pretend,"
        + "pretender;"																			   

        + "24,"
        + "to possess to own,"
        + "poseer;"																  

        + "25,"
        + "to lose,"
        + "perder"
        + "<br/>Indicative_Preterite: perdí  perdiste perdió perdimos perdieron "
        + "<br/>Indicative_Imperfect: perdia perdias perdia perdíamos perdian "
        + "<br/>Indicative_Present: pierdo pierdes pierde perdemos pierden "
        + "<br/>Indicative_Future: perderé perderás perderá perderemos perderán;"

        + "26,"
        + "to put,"
        + "poner"
        + "<br/>Indicative_Preterite: puse pusiste puso pusimos pusieron "
        + "<br/>Indicative_Imperfect: ponia ponias ponia poníamos ponian "
        + "<br/>Indicative_Present: pongo pones pone ponemos ponen "
        + "<br/>Indicative_Future: pondré pondrás pondrá pondremos pondrán;"

        + "27,"
        + "to be able or can,"
        + "poder"
        + "<br/>Indicative_Preterite: pude pudiste pudo pudimos pudieron "
        + "<br/>Indicative_Imperfect: podia podias podia podíamos podian "
        + "<br/>Indicative_Present: puedo puedes puede podemos pueden "
        + "<br/>Indicative_Future: podré podrás podrá podremos podrán;"

        + "28,"
        + "to promise,"
        + "prometer;"

        + "29,"
        + "to want,"
        + "querer"
        + "<br/>Indicative_Preterite: quise quisiste quiso quisemos quisieron "
        + "<br/>Indicative_Imperfect: queria querias queria queríamos querian "
        + "<br/>Indicative_Present: quiero quieres quiere queremos quieren "
        + "<br/>Indicative_Future: querré querrán querrá querremos querrán;"

        + "30,"
        + "to reply,"
        + "responder;"																			  

        + "31,"
        + "to break,"
        + "romper;"

        + "32,"
        + "to know,"
        + "saber"
        + "<br/>Indicative_Preterite: supe supiste supo supimos supieron "
        + "<br/>Indicative_Imperfect: sabia sabias sabia sabíamos sabian "
        + "<br/>Indicative_Present: se sabes sabe sabemos saben "
        + "<br/>Indicative_Future: sabré sabrás sabrá sabremos sabrán;"

        + "33,"
        + "to be,"
        + "ser"
        + "<br/>Indicative_Preterite: fuí fuiste fue fuimos fueron "
        + "<br/>Indicative_Imperfect: era eras era éramos eran "
        + "<br/>Indicative_Present: soy eres es somos son "
        + "<br/>Indicative_Future: seré serás será seremos serán;"

        + "34,"
        + "to have,"
        + "tener"
        + "<br/>Indicative_Preterite: tuve tuviste tuvo tuvimos tuvieron "
        + "<br/>Indicative_Imperfect: tenia tenias tenia teníamos tenian "
        + "<br/>Indicative_Present: tengo tienes tiene tenemos tienen "
        + "<br/>Indicative_Future: tendré tendrás tendrá tendremos tendrán;"

        + "35,"
        + "to fear,"
        + "temer;"

        + "36,"
        + "to cough,"
        + "toser;"

        + "37,"
        + "to bring,"
        + "traer;"

        + "38,"
        + "to return,"
        + "volver"
        + "<br/>Indicative_Preterite: volví volviste volvió volvimos volvieron "
        + "<br/>Indicative_Imperfect: volvia volvias volvia volvíamos volvian "
        + "<br/>Indicative_Present: vuelvo vuelves vuelve volvemos vuelven "
        + "<br/>Indicative_Future: volveré volverás volverá volveremos volverán;"

        + "39,"
        + "to sell,"
        + "vender;"

        + "40,"
        + "to watch,"
        + "ver"
        + "<br/>Indicative_Preterite: ví viste vió vimos vieron "
        + "<br/>Indicative_Imperfect: veia veias veia veíamos veian "
        + "<br/>Indicative_Present: veo vees vee vemos veen "
        + "<br/>Indicative_Future: veré verás verá veremos verán;";

    return verbs;
}
function GetVerbsIR() {
    var verbs = "1,"
        + "to open,"
        + "abrir;"

        + "2,"
        + "to admit,"
        + "admitir;"

        + "3,"
        + "to attend,"
        + "asistir;"

        + "4,"
        + "to cover,"
        + "cubrir;"																	  

        + "5,"
        + "to achieve,"
        + "cumplir;"

        + "6,"
        + "to lead,"
        + "conducir"
        + "<br/>Indicative_Preterite: conduje condujiste condujo condujimos condujeron "
        + "<br/>Indicative_Imperfect: conducia conducias conducia conducíamos conducian "
        + "<br/>Indicative_Present: conduzco conduces conduce conducimos conducen "
        + "<br/>Indicative_Future: conduciré conducirás conducirá conduciremos conducirán;"

        + "7,"
        + "to tell,"
        + "decir"
        + "<br/>Indicative_Preterite: dije dijiste dijo dijimos dijeron "
        + "<br/>Indicative_Imperfect: decia decias decia decíamos decian "
        + "<br/>Indicative_Present: digo dices dice decimos dicen "
        + "<br/>Indicative_Future: diré dirás dirá diremos dirán;"

        + "8,"
        + "to decide,"
        + "decidir;"

        + "9,"
        + "to describe, "
        + "describir;"																				

        + "10,"
        + "to sleep,"
        + "dormir"
        + "<br/>Indicative_Preterite: dormí dormiste durmió dormimos durmieron "
        + "<br/>Indicative_Imperfect: dormia dormias dormia dormíamos dormian "
        + "<br/>Indicative_Present: duermo duermes duerme dormimos duermen "
        + "<br/>Indicative_Future: dormiré dormirás dormirá dormiremos dormirán;"

        + "11,"
        + "to discover,"
        + "descubrir;"																				  

        + "12,"
        + "to argue,"
        + "discutir;"

        + "13,"
        + "to write,"
        + "escribir;"

        + "14,"
        + "to fry,"
        + "freír"
        + "<br/>Indicative_Preterite: freí freiste frió freimos frieron "
        + "<br/>Indicative_Imperfect: freia freias freia freíamos freian "
        + "<br/>Indicative_Present: frio fries frie freimos frien "
        + "<br/>Indicative_Future: freiré freirás freirá frieremos freirán;"

        + "15,"
        + "to hurt,"
        + "herir"
        + "<br/>Indicative_Preterite: herí  heriste hirió herimos hirieron "
        + "<br/>Indicative_Imperfect: heria herias heria heríamos herian "
        + "<br/>Indicative_Present: hiero hieres hiere herimos hieren "
        + "<br/>Indicative_Future: heriré herirás herirá heriremos herirán;"

        + "16,"
        + "to boil,"
        + "hervir"
        + "<br/>Indicative_Preterite: herví herviste hirvió hervimos hervieron "
        + "<br/>Indicative_Imperfect: hervia hervias hervia hervíamos hervian "
        + "<br/>Indicative_Present: hiervo hierves hierve hervimos hierven "
        + "<br/>Indicative_Future: herviré hervirás hervirá herviremos hervirán;"

        + "17,"
        + "to go,"
        + "ir"
        + "<br/>Indicative_Preterite: fuí fuiste fue fuimos fueron "
        + "<br/>Indicative_Imperfect: iba ibas iba íbamos iban "
        + "<br/>Indicative_Present: voy vas va vamos van "
        + "<br/>Indicative_Future: iré irás irá iremos irán;"

        + "18,"
        + "to print,"
        + "imprimir;"

        + "19,"
        + "to die,"
        + "morir"
        + "<br/>Indicative_Preterite: morí moriste murió morimos murieron "
        + "<br/>Indicative_Imperfect: moria morias moria moríamos morian "
        + "<br/>Indicative_Present: muero mueres muere morimos mueren "
        + "<br/>Indicative_Future: moriré morirás morirá moriremos morirán;"

        + "20,"
        + "to hear,"
        + "oir"
        + "<br/>Indicative_Preterite: oí oiste oyó oimos oyeron "
        + "<br/>Indicative_Imperfect: oia oias oia oíamos oian "
        + "<br/>Indicative_Present: oigo oyes oye oimos oyen "
        + "<br/>Indicative_Future: oiré oirás oirá oiremos oirán;"

        + "21,"
        + "to omit,"
        + "omitir;"

        + "23,"
        + "to divide or divide,"
        + "partir;"

        + "24,"
        + "to forbid,"
        + "prohibir;"

        + "25,"
        + "to ask,"
        + "pedir"
        + "<br/>Indicative_Preterite: pedí pediste pidió pedimos pidieron "
        + "<br/>Indicative_Imperfect: pedia pedias pedia pedíamos pedian "
        + "<br/>Indicative_Present: pido pides pide pedimos piden "
        + "<br/>Indicative_Future: pediré pedirás pedirá pediremos pedirán;"

        + "26,"
        + "to permit,"
        + "permitir;"

        + "27,"
        + "to prefer,"
        + "preferir"
        + "<br/>Indicative_Preterite: preferí preferiste prefirió preferimos prefirieon "
        + "<br/>Indicative_Imperfect: preferia preferias preferia preferíamos preferian "
        + "<br/>Indicative_Present: prefiero prefieres prefiere preferimos prefieren "
        + "<br/>Indicative_Future: preferiré preferirás preferirá preferiremos preferirá;"

        + "28,"
        + "to receive,"
        + "recibir;"

        + "29,"
        + "to repeat,"
        + "repetir;"

        + "30,"
        + "to leave,"
        + "salir"
        + "<br/>Indicative_Preterite: salí  saliste salió salimos salieron "
        + "<br/>Indicative_Imperfect: salia salias salia salíamos salian "
        + "<br/>Indicative_Present: salgo sales sale salimos salen "
        + "<br/>Indicative_Future: saldré saldrás saldrá saldremos saldrán;"

        + "31,"
        + "to feel,"
        + "sentir"
        + "<br/>Indicative_Preterite: sentí  sentiste sintió sentimos sintieron "
        + "<br/>Indicative_Imperfect: sentia sentias sentia sentíamos sentian "
        + "<br/>Indicative_Present: siento sientes siente sentimos sienten "
        + "<br/>Indicative_Future: sentiré sentirás sentirá sentiremos sentirán;"

        + "32,"
        + "to follow,"
        + "seguir"
        + "<br/>Indicative_Preterite: seguí seguiste siguió seguimos siguieron "
        + "<br/>Indicative_Imperfect: seguia seguias seguia seguíamos seguian "
        + "<br/>Indicative_Present: sigo sigues sigue seguimos siguen "
        + "<br/>Indicative_Future: seguiré seguirás seguirá seguiremos seguirán;"

        + "33,"
        + "to serve,"
        + "servir"
        + "<br/>Indicative_Preterite: serví serviste sirvió servimos sirvieron "
        + "<br/>Indicative_Imperfect: servia servias servia servíamos servian "
        + "<br/>Indicative_Present: sirvo sirves sirve servimos sirven "
        + "<br/>Indicative_Future: serviré servirás servirá serviremos servirán;"

        + "34,"
        + "to climb,"
        + "subir;"

        + "35,"
        + "to suffer,"
        + "sufrir;"

        + "36,"
        + "to translate,"
        + "traducir"
        + "<br/>Indicative_Preterite: traduje tradujiste tradujo tradujimos tradujeron "
        + "<br/>Indicative_Imperfect: traducia traducias traducia traducíamos traducian "
        + "<br/>Indicative_Present: traduzco traduces traduce traducimos traducen "
        + "<br/>Indicative_Future: traduciré traducirás traducirá traduciremos traducirán;"

        + "37,"
        + "to unite,"
        + "unir;"

        + "38,"
        + "to live,"
        + "vivir;"

        + "39,"
        + "to come,"
        + "venir"
        + "<br/>Indicative_Preterite: vine viniste vino vinimos vinieron "
        + "<br/>Indicative_Imperfect: venia venias venia veníamos venian "
        + "<br/>Indicative_Present: vengo vienes viene venimos vienen "
        + "<br/>Indicative_Future: vendré vendrás vendrá vendremos vendrán;";

    return verbs;
}
function GetVerbs2() {
    var verbs = "1,"
        + " to skate,"
        + " Patinar"
        + "<br/>Indicative_Preterite: patiné patinaste patinó patinamos patinaron"
        + "<br/>Indicative_Present: patino patinas patina patinamos patinan"
        + "<br/>Indicative_Future: patinaré patinarás patinará patinaremos patinarán;"

        + "2,"
        + " to divide,"
        + " Dividir"
        + "<br/>Indicative_Preterite: dividí dividiste dividió dividimos dividieron"
        + "<br/>Indicative_Present: divido divides divide dividimos dividen"
        + "<br/>Indicative_Future: dividiré dividirás dividirá dividiremos dividirán;"

        + "3,"
        + " to leave or depart,"
        + " Partir"
        + "<br/>Indicative_Preterite: partí partiste partió partimos partieron"
        + "<br/>Indicative_Present: parto partes parte partimos parten"
        + "<br/>Indicative_Future: partiré partirás partirá partiremos partirán;"

        + "4,"
        + " to agree,"
        + " Acordar"
        + "<br/>Indicative_Preterite: acordé acordaste acordó acordamos acordaron"
        + "<br/>Indicative_Present: acuerdo acuerdas acuerda acordamos acuerdan"
        + "<br/>Indicative_Future: acordaré acordarás acordará acordaremos acordarán;"

        + "5,"
        + " to keep,"
        + " Guardar"
        + "<br/>Indicative_Preterite: guardé guardaste guardó guardamos guardaron"
        + "<br/>Indicative_Present: guardo guardas guarda guardamos guardan"
        + "<br/>Indicative_Future: guardaré guardarás guardará guardaremos guardarán;"

        + "6,"
        + " to love,"
        + " Encantar"
        + "<br/>Indicative_Preterite: encanté encantaste encantó encantamos encantaron"
        + "<br/>Indicative_Present: encanto encantas encanta encantamos encantan "
        + "<br/>Indicative_Future: encantaré encantarás encantará encantaremos encantarán;"

        + "7,"
        + " to stop,"
        + " Parar"
        + "<br/>Indicative_Preterite: paré paraste paró paramos pararon"
        + "<br/>Indicative_Present: paro paras para paramos paran"
        + "<br/>Indicative_Future: pararé pararás parará pararemos pararán;"

        + "8,"
        + " to finish,"
        + " Acabar"
        + "<br/>Indicative_Preterite: acabé acabaste acabó acabamos acabaron"
        + "<br/>Indicative_Present: acabo acabas acaba acabamos acaban"
        + "<br/>Indicative_Future: acabaré acabarás acabará acabaremos acabarán;"

        + "9,"
        + " to pedal,"
        + " Pedalear"
        + "<br/>Indicative_Preterite: pedaleé pedaleaste pedaleó pedaleamos pedalearon"
        + "<br/>Indicative_Present: pedaleo pedaleas pedalea pedaleamos pedalean"
        + "<br/>Indicative_Future: pedalearé pedalearás pedaleará pedalearemos pedalearán;"

        + "10,"
        + " to stay,"
        + " Quedar"
        + "<br/>Indicative_Preterite: quedé quedaste quedó quedamos quedaron"
        + "<br/>Indicative_Present: quedo quedas queda quedamos quedan"
        + "<br/>Indicative_Future: quedaré quedarás quedará quedaremos quedarán;"

        + "11,"
        + " to get dressed,"
        + " Vestir"
        + "<br/>Indicative_Preterite: vestí vestiste vistió vestimos vistieron"
        + "<br/>Indicative_Present: visto vistes viste vestimos visten"
        + "<br/>Indicative_Future: vestiré vestirás vestirá vestiremos vestirán;"

        + "12,"
        + " to do,"
        + " Realizar"
        + "<br/>Indicative_Preterite: realicé realizaste realizó realizamos realizaron"
        + "<br/>Indicative_Present: realizo realizas realiza realizamos realizan"
        + "<br/>Indicative_Future: realizaré realizarás realizará realizaremos realizarán;"

        + "13,"
        + " to doubt,"
        + " Dudar"
        + "<br/>Indicative_Preterite: dudé dudaste dudó dudamos dudaron"
        + "<br/>Indicative_Present: dudo dudas duda dudamos dudan"
        + "<br/>Indicative_Future: dudaré dudarás dudará dudaremos dudarán;"

        + "14,"
        + " to force,"
        + " Obligar"
        + "<br/>Indicative_Preterite: obligué obligaste obligó obligamos obligaron"
        + "<br/>Indicative_Present: obligo obligas obliga obligamos obligan"
        + "<br/>Indicative_Future: obligaré obligarás obligará obligaremos obligarán;"

        + "15,"
        + " to install,"
        + " Instalar"
        + "<br/>Indicative_Preterite: instalé instalaste instaló instalamos instalaron"
        + "<br/>Indicative_Present: instalo instalas instala instalamos instalan"
        + "<br/>Indicative_Future: instalaré instalarás instalará instalaremos instalarán;"

        + "16,"
        + " to recognize or acknowledge,"
        + " Reconocer"
        + "<br/>Indicative_Preterite: reconocí reconociste reconoció reconocimos reconocieron"
        + "<br/>Indicative_Present: reconozco reconoces reconoce reconocemos reconocen"
        + "<br/>Indicative_Future: reconoceré reconocerás reconocerá reconoceremos reconocerán;"

        + "17,"
        + " to smell,"
        + " Oler"
        + "<br/>Indicative_Preterite: olí olist olió olimos olieron"
        + "<br/>Indicative_Present: huelo hueles huele olemos huelen"
        + "<br/>Indicative_Future: oleré olerás olerá oleremos olerán;"

        + "18,"
        + " to repair,"
        + " Arreglar"
        + "<br/>Indicative_Preterite: arreglé arreglaste arregló arreglamos arreglaron"
        + "<br/>Indicative_Present: arreglo arreglas arregla arreglamos arreglan"
        + "<br/>Indicative_Future: arreglaré arreglarás arreglará arreglaremos arreglarán;"

        + "19,"
        + " to ride,"
        + " Montar"
        + "<br/>Indicative_Preterite: monté montaste montó montamos montaron"
        + "<br/>Indicative_Present: monto montas monta montamos montan"
        + "<br/>Indicative_Future: montaré montarás montará montaremos montarán;"

        + "20,"
        + " to pack,"
        + " Empacar"
        + "<br/>Indicative_Preterite: me-empaqué te-empacaste se-empacó nos-empacamos se-empacaron"
        + "<br/>Indicative_Present: me-empaco te-empacas se-empaca nos-empacamos se-empacan"
        + "<br/>Indicative_Future: me-empacaré te-empacarás se-empacará nos-empacaremos se-empacarán;"

        + "21,"
        + " to proclaim or announce or spread,"
        + " Pregonar"
        + "<br/>Indicative_Preterite: pregoné pregonaste pregonó pregonamos pregonaron"
        + "<br/>Indicative_Present: pregono pregonas pregona pregonamos pregonan"
        + "<br/>Indicative_Future: pregonaré pregonarás pregonará pregonaremos pregonarán;"

        + "22,"
        + " to reach or catch,"
        + " Alcanzar"
        + "<br/>Indicative_Preterite: alcancé alcanzaste alcanzó alcanzamos alcanzaron"
        + "<br/>Indicative_Present: alcanzo alcanzas alcanza alcanzamos alcanzan"
        + "<br/>Indicative_Future: alcanzaré alcanzarás alcanzará alcanzaremos alcanzarán;"

        + "23,"
        + " to develop,"
        + " Desarrollar"
        + "<br/>Indicative_Preterite: desarrollé desarrollaste desarrolló desarrollamos desarrollaron"
        + "<br/>Indicative_Present: desarrollo desarrollas desarrolla desarrollamos desarrollan"
        + "<br/>Indicative_Future: desarrollaré desarrollarás desarrollará desarrollaremos desarrollarán;"

        + "24,"
        + " to stay,"
        + " Quedarse"
        + "<br/>Indicative_Preterite: me-quedé te-quedaste se-quedó nos-quedamos se-quedaron"
        + "<br/>Indicative_Present: me-quedo te-quedas se-queda nos-quedamos se-quedan"
        + "<br/>Indicative_Future: me-quedaré te-quedarás se-quedará nos-quedaremos se-quedarán;"

        + "25,"
        + " to annoy or disturb,"
        + " Molestar"
        + "<br/>Indicative_Preterite: molesté molestaste molestó  olestamos molestaron"
        + "<br/>Indicative_Present: molesto molestas molesta molestamos molestan"
        + "<br/>Indicative_Future: molestaré molestarás molestará molestaremos molestarán;"

        + "26,"
        + " to cheer up or rejoice,"
        + " Alegrar"
        + "<br/>Indicative_Preterite: alegré alegraste alegró alegramos alegraron"
        + "<br/>Indicative_Present: alegro alegras alegra alegramos alegran"
        + "<br/>Indicative_Future: alegraré alegrarás alegrará alegraremos alegrarán;"

        + "27,"
        + " to yell or shout,"
        + " Gritar"
        + "<br/>Indicative_Preterite: grité gritaste gritó gritamos gritaron"
        + "<br/>Indicative_Present: grito gritas grita gritamos gritan"
        + "<br/>Indicative_Future: gritaré gritarás gritará gritaremos gritarán;"

        + "28,"
        + " to go or walk or march or work,"
        + " Marchar"
        + "<br/>Indicative_Preterite: marché marchaste marchó marchamos marcharon"
        + "<br/>Indicative_Present: marcho marchas marcha marchamos marchan"
        + "<br/>Indicative_Future: marcharé marcharás marchará marcharemos marcharán;"

        + "29,"
        + " to choose,"
        + " Elegir"
        + "<br/>Indicative_Preterite: elegí elegiste eligió elegimos eligieron"
        + "<br/>Indicative_Present: elijo eliges elige elegimos eligen"
        + "<br/>Indicative_Future: elegiré elegirás elegirá elegiremos elegirán;"

        + "30,"
        + " to fish,"
        + " Pescar"
        + "<br/>Indicative_Preterite: pesqué pescaste pescó pescamos pescaron"
        + "<br/>Indicative_Present: pesco pescas pesca pescamos pescan"
        + "<br/>Indicative_Future: pescaré pescarás pescará pescaremos pescarán;"

        + "31,"
        + " to ruin,"
        + " Arruinar"
        + "<br/>Indicative_Preterite: arruiné arruinaste arruinó arruinamos arruinaron"
        + "<br/>Indicative_Present: arruino arruinas arruina arruinamos arruinan"
        + "<br/>Indicative_Future: arruinaré arruinarás arruinará arruinaremos arruinarán;"

        + "32,"
        + " to give or string or inflict,"
        + " Propinar"
        + "<br/>Indicative_Preterite: propiné propinaste propinó propinamos propinaron"
        + "<br/>Indicative_Present: propino propinas propina propinamos propinan"
        + "<br/>Indicative_Future: propinaré propinarás propinará propinaremos propinarán;"

        + "33,"
        + " to suck,"
        + " Chupar"
        + "<br/>Indicative_Preterite: chupé chupaste chupó chupamos chuparon"
        + "<br/>Indicative_Present: chupo chupas chupa chupamos chupan"
        + "<br/>Indicative_Future: chuparé chuparás chupará chuparemos chuparán;"

        + "34,"
        + " to breath,"
        + " Respiran"
        + "<br/>Indicative_Preterite: respiré respiraste respiró respiramos respiraron"
        + "<br/>Indicative_Present: respiro respiras respira respiramos respiran"
        + "<br/>Indicative_Future: respiraré respirarás respirará respiraremos respirarán;"

        + "35,"
        + " to tremble,"
        + " Temblar"
        + "<br/>Indicative_Preterite: temblé temblaste tembló temblamos temblaron"
        + "<br/>Indicative_Present: tiemblo tiemblas tiembla temblamos tiemblan"
        + "<br/>Indicative_Future: temblaré temblarás temblará temblaremos temblarán;"

        + "36,"
        + " to camp,"
        + " Acampar"
        + "<br/>Indicative_Preterite: acampé acampaste acampó acampamos acamparon"
        + "<br/>Indicative_Present: acampo acampas acampa acampamos acampan"
        + "<br/>Indicative_Future: acamparé acamparás acampará acamparemos acamparán;"

        + "37,"
        + " to check or verify,"
        + " Comprobar"
        + "<br/>Indicative_Preterite: comprobé comprobaste comprobó comprobamos comprobaron"
        + "<br/>Indicative_Present: compruebo compruebas comprueba comprobamos comprueban"
        + "<br/>Indicative_Future: comprobaré comprobarás comprobará comprobaremos comprobarán;"

        + "38,"
        + " to dedicate,"
        + " Dedicar"
        + "<br/>Indicative_Preterite: dediqué dedicaste dedicó dedicamos dedicaron"
        + "<br/>Indicative_Present: dedico dedicas dedica dedicamos dedican"
        + "<br/>Indicative_Future: dedicaré dedicarás dedicará dedicaremos dedicarán;"

        + "39,"
        + " to base,"
        + " Basar"
        + "<br/>Indicative_Preterite: basé basaste basó basamos basaron"
        + "<br/>Indicative_Present: baso basas basa basamos basan"
        + "<br/>Indicative_Future: basaré basarás basará basaremos basarán;"

        + "40,"
        + " to propose,"
        + " Proponer"
        + "<br/>Indicative_Preterite: propuse propusiste propuso propusimos propusieron"
        + "<br/>Indicative_Present: propongo propones propone proponemos proponen"
        + "<br/>Indicative_Future: propondré propondrás propondrá propondremos propondrán;"

        + "41,"
        + " to improve,"
        + " Mejorar"
        + "<br/>Indicative_Preterite: mejoré mejoraste mejoró mejoramos mejoraron"
        + "<br/>Indicative_Present: mejoro mejoras mejora mejoramos mejoran"
        + "<br/>Indicative_Future: mejoraré mejorarás mejorará mejoraremos mejorarán;"

        + "42,"
        + " to hunt,"
        + " Cazar"
        + "<br/>Indicative_Preterite: cacé cazaste cazó cazamos cazaron"
        + "<br/>Indicative_Present: cazo cazas caza cazamos cazan"
        + "<br/>Indicative_Future: cazaré cazarás cazará cazaremos cazarán;"

        + "43,"
        + " to guess,"
        + " Adivinar"
        + "<br/>Indicative_Preterite: adiviné adivinaste adivinó adivinamos adivinaron"
        + "<br/>Indicative_Present: adivino adivinas adivina adivinamos adivinan"
        + "<br/>Indicative_Future: adivinaré adivinarás adivinará adivinaremos adivinarán;"

        + "44,"
        + " to warm or heat,"
        + " Calentar"
        + "<br/>Indicative_Preterite: calenté calentaste calentó calentamos calentaron"
        + "<br/>Indicative_Present: caliento calientas calienta calentamos calientan"
        + "<br/>Indicative_Future: calentaré calentarás calentará calentaremos calentarán;"

        + "45,"
        + " to guess or predict,"
        + " Adivinar"
        + "<br/>Indicative_Preterite: adiviné adivinaste adivinó adivinamos adivinaron"
        + "<br/>Indicative_Present: adivino adivinas adivina adivinamos adivinan"
        + "<br/>Indicative_Future: adivinaré adivinarás adivinará adivinaremos adivinarán;";  //required for end of verb string

    return verbs;
}