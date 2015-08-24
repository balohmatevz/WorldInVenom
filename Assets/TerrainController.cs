using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainController : MonoBehaviour {
    
    public const int TERRAINTYPE_GRASS1 = 1;
    public const int TERRAINTYPE_GRASS2 = 2;
    public const int TERRAINTYPE_GRASS3 = 3;
    public const int TERRAINTYPE_CONCRETE = 4;

    public static string[] maleNames = new string[]{"Oliver","Jack","Charlie","Harry","Oscar","Thomas","Jacob","Ethan","Noah","James","William","Joshua","George","Leo","Max","Henry","Alfie","Lucas","Daniel","Dylan","Finley","Alexander","Freddie","Isaac","Samuel","Joseph","Archie","Muhammad","Benjamin","Lewis","Logan","Matthew","Sebastian","Jake","Edward","Zachary","Aidan","Luke","Mason","Riley","Ryan","Elliott","Toby","Reuben","Adam","Theo","Connor","Nathan","Jayden","Liam","Harrison","Sam","Michael","Ollie","Zack","Arthur","Luca","Ben","Finn","Elijah","Alex","Tyler","Jamie","Blake","Rhys","David","Caleb","Callum","Jackson","Harvey","Felix","Jenson","Jude","Aaron","Cameron","Tommy","Hugo","Brody","Evan","Gabriel","Dexter","Austin","Nicholas","Seth","Harley","Owen","Stanley","Nathaniel","Rowan","Rory","Teddy","Jason","Hayden","Tristan","Josh","Jasper","Bobby","Frankie","Tom","Patrick"};
    public static string[] femaleNames = new string[]{"Olivia","Emily","Sophia","Lily","Isabella","Isabelle","Amelia","Isla","Sophie","Ava","Chloe","Poppy","Jessica","Mia","Ella","Grace","Evie","Lucy","Alice","Layla","Ruby","Holly","Annabelle","Charlotte","Molly","Freya","Scarlett","Daisy","Emma","Eva","Hannah","Erin","Maya","Phoebe","Sienna","Ellie","Amelie","Millie","Matilda","Anna","Maisie","Amy","Imogen","Zoe","Elsie","Darcy","Megan","Elizabeth","Abigail","Summer","Lola","Evelyn","Esme","Georgia","Rose","Rosie","Amber","Eliza","Florence","Francesca","Harriet","Caitlin","Jasmine","Thea","Aria","Mila","Madison","Ivy","Bella","Willow","Lexi","Niamh","Katie","Elena","Eleanor","Zara","Leah","Alexandra","Eloise","Lottie","Robyn","Lara","Sarah","Martha","Violet","Bethany","Rebecca","Victoria","Gabriella","Naomi","Lauren","Clara","Maria","Maryam","Orla","Eve","Iris","Kayla","Seren","Sadie"};
    public static string[] surnames = new string[]{"Smith","Johnson","Williams","Jones","Brown","Davis","Miller","Wilson","Moore","Taylor","Anderson","Thomas","Jackson","White","Harris","Martin","Thompson","Garcia","Martinez","Robinson","Clark","Rodriguez","Lewis","Lee","Walker","Hall","Allen","Young","Hernandez","King","Wright","Lopez","Hill","Scott","Green","Adams","Baker","Gonzalez","Nelson","Carter","Mitchell","Perez","Roberts","Turner","Phillips","Campbell","Parker","Evans","Edwards","Collins","Stewart","Sanchez","Morris","Rogers","Reed","Cook","Morgan","Bell","Murphy","Bailey","Rivera","Cooper","Richardson","Cox","Howard","Ward","Torres","Peterson","Gray","Ramirez","James","Watson","Brooks","Kelly","Sanders","Price","Bennett","Wood","Barnes","Ross","Henderson","Coleman","Jenkins","Perry","Powell","Long","Patterson","Hughes","Flores","Washington","Butler","Simmons","Foster","Gonzales","Bryant","Alexander","Russell","Griffin","Diaz","Hayes","Myers","Ford","Hamilton","Graham","Sullivan","Wallace","Woods","Cole","West","Jordan","Owens","Reynolds","Fisher","Ellis","Harrison","Gibson","Mcdonald","Cruz","Marshall","Ortiz","Gomez","Murray","Freeman","Wells","Webb","Simpson","Stevens","Tucker","Porter","Hunter","Hicks","Crawford","Henry","Boyd","Mason","Morales","Kennedy","Warren","Dixon","Ramos","Reyes","Burns","Gordon","Shaw","Holmes","Rice","Robertson","Hunt","Black","Daniels","Palmer","Mills","Nichols","Grant","Knight","Ferguson","Rose","Stone","Hawkins","Dunn","Perkins","Hudson","Spencer","Gardner","Stephens","Payne","Pierce","Berry","Matthews","Arnold","Wagner","Willis","Ray","Watkins","Olson","Carroll","Duncan","Snyder","Hart","Cunningham","Bradley","Lane","Andrews","Ruiz","Harper","Fox","Riley","Armstrong","Carpenter","Weaver","Greene","Lawrence","Elliott","Chavez","Sims","Austin","Peters","Kelley","Franklin","Lawson","Fields","Gutierrez","Ryan","Schmidt","Carr","Vasquez","Castillo","Wheeler","Chapman","Oliver","Montgomery","Richards","Williamson","Johnston","Banks","Meyer","Bishop","Mccoy","Howell","Alvarez","Morrison","Hansen","Fernandez","Garza","Harvey","Little","Burton","Stanley","Nguyen","George","Jacobs","Reid","Kim","Fuller","Lynch","Dean","Gilbert","Garrett","Romero","Welch","Larson","Frazier","Burke","Hanson","Day","Mendoza","Moreno","Bowman","Medina","Fowler","Brewer","Hoffman","Carlson","Silva","Pearson","Holland","Douglas","Fleming","Jensen","Vargas","Byrd","Davidson","Hopkins","May","Terry","Herrera","Wade","Soto","Walters","Curtis","Neal","Caldwell","Lowe","Jennings","Barnett","Graves","Jimenez","Horton","Shelton","Barrett","O'brien","Castro","Sutton","Gregory","Mckinney","Lucas","Miles","Craig","Rodriquez","Chambers","Holt","Lambert","Fletcher","Watts","Bates","Hale","Rhodes","Pena","Beck","Newman","Haynes","Mcdaniel","Mendez","Bush","Vaughn","Parks","Dawson","Santiago","Norris","Hardy","Love","Steele","Curry","Powers","Schultz","Barker","Guzman","Page","Munoz","Ball","Keller","Chandler","Weber","Leonard","Walsh","Lyons","Ramsey","Wolfe","Schneider","Mullins","Benson","Sharp","Bowen","Daniel","Barber","Cummings","Hines","Baldwin","Griffith","Valdez","Hubbard","Salazar","Reeves","Warner","Stevenson","Burgess","Santos","Tate","Cross","Garner","Mann","Mack","Moss","Thornton","Dennis","Mcgee","Farmer","Delgado","Aguilar","Vega","Glover","Manning","Cohen","Harmon","Rodgers","Robbins","Newton","Todd","Blair","Higgins","Ingram","Reese","Cannon","Strickland","Townsend","Potter","Goodwin","Walton","Rowe","Hampton","Ortega","Patton","Swanson","Joseph","Francis","Goodman","Maldonado","Yates","Becker","Erickson","Hodges","Rios","Conner","Adkins","Webster","Norman","Malone","Hammond","Flowers","Cobb"};

    public const int DECOR_TREE = 1;
    public const int DECOR_BUSH = 2;
    GameObject PrefabHuman;

    public GameObject FloorRoot;
    public GameObject DecorRoot;
    
    GameObject PrefabTree;
    GameObject PrefabRock;
    GameObject PrefabHouse;
    GameObject PrefabFloor;
    GameObject PrefabBush;
    GameObject PrefabWell;
    GameObject PrefabStore;
    

    public static int SizeX = 50;
    public static int SizeY = 50;
    int[,] Map;
    int[,] Decor;
    List<Vector2> TownCooreinates;
    
    public static int NumberOfTowns = 6;
    public static int NumberOfRoads = 30;
    public static int NumberOfTrees = 3000;
    public static int NumberOfBushes = 3000;
    public static int NumberOfRocks = 3000;
    public static int MinTownSize = 10;
    public static int MaxTownSize = 100;
    public static int MinDistanceBetweenTowns = 20;
    public static List<Town> townList;


	// Use this for initialization
	void Awake () {
        PrefabHuman = Resources.Load<GameObject>("Prefabs/Human");
        PrefabRock = Resources.Load<GameObject>("Prefabs/Rock");
        PrefabTree = Resources.Load<GameObject>("Prefabs/Tree");
        PrefabHouse = Resources.Load<GameObject>("Prefabs/House");
        PrefabFloor = Resources.Load<GameObject>("Prefabs/Floor");
        PrefabBush = Resources.Load<GameObject>("Prefabs/Bush");
        PrefabWell = Resources.Load<GameObject>("Prefabs/Well");
        PrefabStore = Resources.Load<GameObject>("Prefabs/Store");
        TownCooreinates = new List<Vector2>();
        townList = new List<Town>();
        
        Map = new int[SizeX * 10 + 1, SizeY * 10 + 1];
        Decor = new int[SizeX * 10 + 1, SizeY * 10 + 1];

	    GenerateTerrain();
        GenerateTowns();
        PopulateTowns();
        GenerateRoads();
	    GenerateDecor();
        CreateTerrainObjects();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void GenerateTerrain(){
        for(int x = 0; x < SizeX * 10 + 1; x++){
            for(int y = 0; y < SizeY * 10 + 1; y++){
                Map[x, y] = Random.Range(1, 4);
            }
        }
    }

    public void CreateRoad(Vector2 from, Vector2 to){
        if(to.x < from.x){
            Vector2 tmp = from;
            from = to;
            to = tmp;
        }

        if(from.x == to.x){
            //Vertical line, ugh.
            to.x += 1;
        }
            
        float k = (to.y - from.y) / (to.x - from.x);
        float dX = (to.x - from.x) / 1000;

        //Create road
        for(int j = 0; j < 1000; j++){
            float y = k * (j * dX) + from.y;
            int posX = FitToX((int)(from.x + (j * dX)));
            int posY = FitToY((int)y);

            Map[posX, posY] = TERRAINTYPE_CONCRETE;
        }
    }

    public void GenerateTowns(){
        //Generate town
        for(int i = 0; i < NumberOfTowns; i++){
            //Generate starting location
            int townPosX = 0;
            int townPosY = 0;
            for(int j = 0; j < 100; j++){
                //max 100 attempts
                float rndX1 =  Random.Range(20, (SizeX - 2) * 10f);
                float rndX2 =  Random.Range(20, (SizeX - 2) * 10f);
                int rndX = (int)(((rndX1 + rndX2) / 2f));

                float rndY1 = Random.Range(20, (SizeY - 2) * 10f);
                float rndY2 = Random.Range(20, (SizeY - 2) * 10f);
                int rndY = (int)((rndY1 + rndY2) / 2f);
            
                bool minDistanceCheckPass = true;
                foreach(Vector2 town in TownCooreinates){
                    if(Vector2.Distance(new Vector2(rndX, rndY), town) < MinDistanceBetweenTowns){
                        minDistanceCheckPass = false;
                    }
                }
                if(minDistanceCheckPass){
                    townPosX = rndX;
                    townPosY = rndY;
                    break;
                }
            }

            //Store town coordinates
            TownCooreinates.Add(new Vector2(townPosX, townPosY));
            Town townData = new Town(new Vector2(townPosX, townPosY));
 
            for(int dX = -1; dX <= 1; dX++){
                for(int dY = -1; dY <= 1; dY++){
                    Decor[(int)(townPosX + dX), (int)(townPosY + dY)] = 3;
                    Map[(int)(townPosX + dX), (int)(townPosY + dY)] = TERRAINTYPE_CONCRETE;
                }
            }
            
            //Create well
            GameObject go = Instantiate<GameObject>(PrefabWell);
            go.transform.position = new Vector3(townPosX, 0.5f, townPosY);
            go.transform.SetParent(DecorRoot.transform);
            townData.well = go.GetComponent<Well>();

            int numberOfHouses = Random.Range(MinTownSize, MaxTownSize);
            int maxTownSize = (int)(5 + Mathf.Sqrt(numberOfHouses) * 4);

            bool townStore = false;

            //Create buildings
            for(int j = 0; j < numberOfHouses; j++){
                //Generate building location
                int buildingPosX1 =  Random.Range(-maxTownSize, maxTownSize);
                int buildingPosX2 =  Random.Range(-maxTownSize, maxTownSize);
                int buildingPosX3 =  Random.Range(-maxTownSize, maxTownSize);
                int buildingPosX = (int)((buildingPosX1 + buildingPosX2 + buildingPosX3) / 3f);
                int buildingPosY1 =  Random.Range(-maxTownSize, maxTownSize);
                int buildingPosY2 =  Random.Range(-maxTownSize, maxTownSize);
                int buildingPosY3 =  Random.Range(-maxTownSize, maxTownSize);
                int buildingPosY = (int)((buildingPosY1 + buildingPosY2 + buildingPosY3) / 3f);
                
                bool spotTaken = false;
                for(int dX = -1; dX <= 1; dX++){
                    for(int dY = -1; dY <= 1; dY++){
                        //Debug.Log((rndX + buildingPosX + dX) + "; " + (rndY + buildingPosY + dY));
                        int locX = FitToX((int)(townPosX + buildingPosX + dX));
                        int locY = FitToY((int)(townPosY + buildingPosY + dY));
                        if(Decor[locX, locY] != 0){
                            //Spot already taken
                            spotTaken = true;
                            break;
                        }
                    }
                }

                if(spotTaken){
                    continue;
                }

                if(!townStore){
                    townStore = true;
                    go = Instantiate<GameObject>(PrefabStore);
                    townData.Store = new Vector2((townPosX + buildingPosX), (townPosY + buildingPosY));
                }else{
                    go = Instantiate<GameObject>(PrefabHouse);
                    townData.HouseList.Add(new Vector2((townPosX + buildingPosX), (townPosY + buildingPosY)));
                    townData.HouseDataList.Add(go.GetComponent<House>());
                }
                go.transform.position = new Vector3(townPosX + buildingPosX, 0.055f, townPosY + buildingPosY);
                go.transform.SetParent(DecorRoot.transform);
                
                for(int dX = -1; dX <= 1; dX++){
                    for(int dY = -1; dY <= 1; dY++){
                        int posX = FitToX((int)(townPosX + buildingPosX + dX));
                        int posY = FitToY((int)(townPosY + buildingPosY + dY));
                        Decor[posX, posY] = 2;
                    }
                }

                CreateRoad(new Vector2((townPosX + buildingPosX), (townPosY + buildingPosY)), new Vector2(townPosX, townPosY));
            }
            Debug.Log("aadd" + townData.HouseList.Count);
            townList.Add(townData);
        }
    }

    public void PopulateTowns(){
        for(int i = 0; i < townList.Count; i++){
            Town town = townList[i];
            for(int j = 0; j < town.HouseDataList.Count; j++){
                //Create family
                House house = town.HouseDataList[j];
                string housename = TerrainController.surnames[Random.Range(0, TerrainController.surnames.Length)];
                house.itemTitle = housename+" residence";
                int familySize1 = Random.Range(0, 6);
                int familySize2 = Random.Range(0, 6);
                int familySize3 = Random.Range(0, 6);
                int familySize = (familySize1 + familySize2 + familySize3) / 3;
                if(familySize == 0){
                    house.itemTitle = "Vacant residence";
                }
                for(int k = 0; k < familySize; k++){
                    GameObject humango = Instantiate(PrefabHuman);
                    humango.transform.position = new Vector3(town.HouseList[j].x, 0, town.HouseList[j].y);
                    Human human = humango.GetComponent<Human>();
                    human.livesInTown = town;
                    human.livesInHouse = house;
                    town.inhabitantsList.Add(humango.GetComponent<Human>());
                    house.family.Add(humango.GetComponent<Human>());
                    human.housename = housename;
                    //Debug.Log("aBaer"+  house.family.Count);

                }
            }
        }
    }

    public void GenerateRoads(){
        //Generate roads
        for(int i = 0; i < NumberOfRoads; i++){
            int town1ID = Random.Range(0, TownCooreinates.Count);
            int town2ID = Random.Range(0, TownCooreinates.Count);
            if(town1ID == town2ID){
                continue;
            }
            
            Vector2 town1 = TownCooreinates[town1ID];
            Vector2 town2 = TownCooreinates[town2ID];

            CreateRoad(town1, town2);
        }
    }

    public int FitToX(int X){
        return (int)(Mathf.Min(SizeX * 10, Mathf.Max(0, X)));
    }

    public int FitToY(int X){
        return (int)(Mathf.Min(SizeY * 10, Mathf.Max(0, X)));
    }

    public float FitToX(float X){
        return (Mathf.Min(SizeX * 10, Mathf.Max(0, X)));
    }

    public float FitToY(float X){
        return (Mathf.Min(SizeY * 10, Mathf.Max(0, X)));
    }

    public void GenerateDecor(){
        GenerateTrees();
        GenerateBushes();


        WriteDecorToFile();
    }

    public void CreateTerrainObjects(){
        for(int x = 0; x < SizeX; x++){
            for(int y = 0; y < SizeY; y++){
                GameObject go = Instantiate(PrefabFloor);
                go.transform.position = new Vector3(x * 10 + 5, 0, y * 10 + 5);
                go.transform.rotation = Quaternion.identity;
                go.transform.Rotate(0, 180, 0);
                go.transform.localScale = Vector3.one;
                go.transform.SetParent(FloorRoot.transform);
                go.name = "floor "+x+", "+y;
                MeshFilter viewedModelFilter = (MeshFilter)go.GetComponent("MeshFilter");
                Mesh mesh = viewedModelFilter.mesh;
                Color[] colors = new Color[mesh.vertices.Length];
                for(int i = 0; i < mesh.vertices.Length; i++){
                    if(i > 15){
                        //continue;
                    }
                    int coordX = (x * 10) + (i % 11);
                    int coordY = (y * 10) + (i / 11);

                    int terrain = Map[coordX, coordY];

                    Color c;
                    switch(terrain){
                        case TERRAINTYPE_GRASS1:
                            c = new Color(8 / 256f, 126 / 256f, 5 / 256f);
                            //c = new Color(1,0,0);
                            break;
                        case TERRAINTYPE_GRASS2:
                            c = new Color(16 / 256f, 153 / 256f, 13 / 256f);
                            //c = new Color(0,1,0);
                            break;
                        case TERRAINTYPE_GRASS3:
                            c = new Color(12 / 256f, 143 / 256f, 9 / 256f);
                            //c = new Color(0,0,1);
                            break;
                        case TERRAINTYPE_CONCRETE:
                            c = new Color(143 / 256f, 143 / 256f, 143 / 256f);
                            break;
                        default:
                            c = new Color(0, 0, 0);
                            break;
                    }
                    colors[i] = c;
                }
                mesh.colors = colors;
            }
        }

        WriteMapToFile();
    }

    public void GenerateTrees(){
        GenerateDecorDistribution(PrefabTree, 4, NumberOfTrees, DECOR_TREE, true, new Vector3((SizeX * 10) / 2, -0.029f, (SizeY * 10) / 2));
    }

    public void GenerateDecorDistribution(GameObject prefabVar, int normalIterations, int numberToGenerate, int decorType, bool isPlant, Vector3 centerPosition){
        //Generate decor
        for(int i = 0; i < numberToGenerate; i++){
            //Generate position (normal distribution
            float rndX = 0;
            float rndY = 0;
            for(int j = 0; j < normalIterations; j++){
                rndX += Random.Range(-(SizeX * 10) /2f +3, ((SizeX * 10) /2f) -3);
                rndY += Random.Range(-(SizeY * 10) /2f +3, ((SizeY * 10) /2f) -3);
            }

            int posX = (int)(rndX / normalIterations) +3;
            int posY = (int)(rndY / normalIterations) +3;

            if(!IsSpotFree(posX + (int)centerPosition.x, posY + (int)centerPosition.z)){
                continue;
            }

            if(isPlant){
                if(!CanGrowPlants(posX + (int)centerPosition.x, posY + (int)centerPosition.z)){
                    continue;
                }
            }

            CreateDecor(prefabVar, new Vector3(posX, 0, posY) + centerPosition, DecorRoot.transform, decorType);
        }
    }

    public void GenerateBushes(){
        GenerateDecorDistribution(PrefabBush, 1, NumberOfBushes, DECOR_BUSH, true, new Vector3((SizeX * 10) / 2, -0.029f, (SizeY * 10) / 2));
    }

    public bool IsSpotFree(int x, int y){
        return (Decor[x, y] == 0);
    }

    public bool CanGrowPlants(int x, int y){
        return (Map[x, y] <= TERRAINTYPE_GRASS3);
    }

    public void CreateDecor(GameObject prefabVar, Vector3 position, Transform parent, int decorType){
        GameObject go = Instantiate<GameObject>(prefabVar);
        go.transform.position = position;
        go.transform.SetParent(parent);
        Decor[(int)position.x, (int)position.y] = decorType;
    }

    public void WriteMapToFile(){
        System.IO.StreamWriter file = new System.IO.StreamWriter("map.txt");
        for(int x = 0; x < SizeX * 10 + 1; x++){
            for(int y = 0; y < SizeY * 10 + 1; y++){
                file.Write(Map[x, y]+" ");
            }
            file.Write("\n");
        }
        file.Close();
    }

    public void WriteDecorToFile(){
        System.IO.StreamWriter file = new System.IO.StreamWriter("decor.txt");
        for(int x = 0; x < SizeX * 10 + 1; x++){
            for(int y = 0; y < SizeY * 10 + 1; y++){
                file.Write(Decor[x, y]+" ");
            }
            file.Write("\n");
        }
        file.Close();
    }
}


public class Town{
    public Vector2 Pos;
    public List<Vector2> HouseList;
    public List<House> HouseDataList;
    public Vector2 Store;
    public List<Human> inhabitantsList;
    public Well well;

    public Town(Vector2 pos){
        Pos = pos;
        Store = new Vector3(0, 0);
        HouseList = new List<Vector2>();
        HouseDataList = new List<House>();
        inhabitantsList = new List<Human>();
    }
}