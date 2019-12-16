# Monopoly-project

## Simplified version of Monopoly using Design Patterns - Project

Our simplified version of Monopoly is a board game composed of 40 lands and to be played by 2 to 4 peoples. There are several type of land a player can go on. Players use a pair of dice to decide where they are going to move. The game ends after a specific number of turn as been played or if only one player still has money.  
This Monopoly game has been implemented using some Design Patterns, and trying to make it as dynamical as possible and following C# naming conventions.

#### List of lands :
- Go : here is where all player starts with 1500$
- Station : can be owned for 100$. If a player goes this land and belong to someone, he's charge with 100$ for the owner
- Street : can be owned for 150$. If a player goes this land and belong to someone, he's charge with 150$ for the owner
- Parking : can be owned for 20$. If a player goes this land and belong to someone, he's charge with 20$ for the owner
- Tax : when on this land, the player pay 40$ of taxes
- Chance : when on this land, the player pick a Chance card
- Community : when on this land, the player pick a Community card
- Jail : the player on this land is either visting a friend or behind bars himself
- Go To Jail : when on this land, the player instantly goes to Jail and is prisoner

## Design Pattern

### Singleton

**Singleton** is a creational design pattern that ensure that a class has only one instance, while providing a global access point to this instance. That is implemented following this UML :   
![UMLsingleton](https://www.dofactory.com/images/diagrams/net/singleton.gif)

Here a unique **board game** is used and is accessible by other classes thus we decided that the implementation of a singleton pattern for BoardGame was relevant. 
```c#
public class BoardGame
    {
        private static BoardGame instance = new BoardGame();
        private static readonly int size = 40;
        private List<Box> squares = new List<Box>(size);

        public static BoardGame GetInstance()
        {
            return instance;
        }

        private BoardGame()
        {
            var listBoxes = new ListBox();
            squares = listBoxes.Boxes;
        }
    }
```

The BoardGame() constructor is private so it can be instanciate only in the BoardGame class. With .NET static members are initialized immediately when the class is loaded for the first time so ```private static BoardGame instance = new BoardGame();``` guarantees thread safety.

### Factory Method

**Factory Method** is a creational design pattern that provides an interface for creating objects in a superclass, but allows subclasses to alter the type of objects that will be created. It is implemented following the UML : 

![UMLfactoty](https://www.dofactory.com/images/diagrams/net/factory.gif)

Here //TO FINISH//

Participants:
- Creator : ListBoxFactory
- ConcretCreator : ListBox
- Product : Box
- ConcretProduct : GoBox, TaxBox, StreetBox, JailBox, GoToJailBox, ChanceBox, CommunityBox, StationBox, ParkingBox

Creator :
```C#
abstract class ListBoxFactory
    {
        private List<Box> _boxes = new List<Box>();

        public ListBoxFactory()
        {
            CreateListBoxes();
        }
        public abstract void CreateListBoxes();
    }
```
ConcretCreator :
```C#
class ListBox : ListBoxFactory
    {
        public override void CreateListBoxes()
        {
            Boxes.Add(new GoBox());             //1
            Boxes.Add(new StreetBox("1"));      //2
            ....
            Boxes.Add(new StreetBox("22"));     //40
        }
    }
```
Product :
```C#
public abstract class Box //Factory pattern
    {
        protected string box_name;
        protected int box_value;
        protected Player owner;

        public Box(string box_name, int box_value)
        {
            this.box_name = box_name;
            this.box_value = box_value;
        }
        public string Box_name
        {
            get { return box_name; }
            set { box_name = value; }
        }

        public int Box_value
        {
            get { return box_value; }
            set { box_value = value; }
        }

        public Player Owner
        {
            get { return owner; }
            set { owner = value; }
        }
    }
```
ConcreteProduct example : 
```C#
class JailBox : Box
    {
        public new string Box_name
        {
            get { return this.box_name; }
            set { this.box_name = value; }
        }

        public new int Box_value
        {
            get { return this.box_value; }
            set { this.box_value = value; }
        }

        public JailBox() : base("Jail", 0)
        {
            this.owner = null;
        }
    }
```


### State

**State** is a behavioral design pattern that allows an object to change the behavior when its internal state changes. It is implemented following the UML : 

![UMLstate](https://www.dofactory.com/images/diagrams/net/state.gif)

Here a **player** can be either a **prisoner** or **free**, these are two state he can be in. So it is relevent to create an interface *IStatePlayer* that will associate the behavior of a Player.

//TO FINISH//

## Conclusion

We tried to code this simplified version of Monopoly using the more approriate patterns of us. Because we were limited in time we didn't code the entire Monopoly game and didn't yet automitised the game to be able to play with the computer. However I hope you appreciate our effort. I know that our UI is claqué au sol because on the console but at least it works. 🙂

#### Made by :
  * Carla CAUCHE
  * Yasmina BENDAOUD
