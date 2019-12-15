using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class ListBox : ListBoxFactory
    {
        public override void CreateListBoxes()
        {
            Boxes.Add(new GoBox());             //1
            Boxes.Add(new StreetBox("1"));      //2
            Boxes.Add(new CommunityBox());      //3
            Boxes.Add(new StreetBox("2"));      //4
            Boxes.Add(new TaxBox());            //5
            Boxes.Add(new StationBox());        //6
            Boxes.Add(new StreetBox("3"));      //7
            Boxes.Add(new ChanceBox());         //8
            Boxes.Add(new StreetBox("4"));      //9
            Boxes.Add(new StreetBox("5"));      //10
            Boxes.Add(new JailBox());           //11
            Boxes.Add(new StreetBox("6"));      //12
            Boxes.Add(new TaxBox());            //13
            Boxes.Add(new StreetBox("7"));      //14
            Boxes.Add(new StreetBox("8"));      //15
            Boxes.Add(new StationBox());        //16
            Boxes.Add(new StreetBox("9"));      //17
            Boxes.Add(new CommunityBox());      //18
            Boxes.Add(new StreetBox("10"));     //19
            Boxes.Add(new StreetBox("11"));     //20
            Boxes.Add(new ParkingBox());        //21
            Boxes.Add(new StreetBox("12"));     //22
            Boxes.Add(new ChanceBox());         //23
            Boxes.Add(new StreetBox("13"));     //24
            Boxes.Add(new StreetBox("14"));     //25
            Boxes.Add(new StationBox());        //26
            Boxes.Add(new StreetBox("15"));     //27
            Boxes.Add(new StreetBox("16"));     //28
            Boxes.Add(new TaxBox());            //29
            Boxes.Add(new StreetBox("17"));     //30
            Boxes.Add(new GoToJailBox());       //31
            Boxes.Add(new StreetBox("18"));     //32
            Boxes.Add(new StreetBox("19"));     //33
            Boxes.Add(new CommunityBox());      //34
            Boxes.Add(new StreetBox("20"));     //35
            Boxes.Add(new StationBox());        //36
            Boxes.Add(new ChanceBox());         //37
            Boxes.Add(new StreetBox("21"));     //38
            Boxes.Add(new TaxBox());            //39
            Boxes.Add(new StreetBox("22"));     //40

            /*
             Boxes.Add(new GoBox());             //1
            Boxes.Add(new StreetBox("Brown"));  //2
            Boxes.Add(new CommunityBox());      //3
            Boxes.Add(new StreetBox("Brown"));  //4
            Boxes.Add(new TaxBox());            //5
            Boxes.Add(new StationBox());        //6
            Boxes.Add(new StreetBox("Ligth Blue")); //7
            Boxes.Add(new ChanceBox());         //8
            Boxes.Add(new StreetBox("Ligth Blue")); //9
            Boxes.Add(new StreetBox("Ligth Blue")); //10
            Boxes.Add(new JailBox());           //11
            Boxes.Add(new StreetBox("Pink"));   //12
            Boxes.Add(new TaxBox());            //13
            Boxes.Add(new StreetBox("Pink"));   //14
            Boxes.Add(new StreetBox("Pink"));   //15
            Boxes.Add(new StationBox());        //16
            Boxes.Add(new StreetBox("Orange")); //17
            Boxes.Add(new CommunityBox());      //18
            Boxes.Add(new StreetBox("Orange")); //19
            Boxes.Add(new StreetBox("Orange")); //20
            Boxes.Add(new ParkingBox());        //21
            Boxes.Add(new StreetBox("Red"));    //22
            Boxes.Add(new ChanceBox());         //23
            Boxes.Add(new StreetBox("Red"));    //24
            Boxes.Add(new StreetBox("Red"));    //25
            Boxes.Add(new StationBox());        //26
            Boxes.Add(new StreetBox("Yellow")); //27
            Boxes.Add(new StreetBox("Yellow")); //28
            Boxes.Add(new TaxBox());            //29
            Boxes.Add(new StreetBox("Yellow")); //30
            Boxes.Add(new GoToJailBox());       //31
            Boxes.Add(new StreetBox("Green"));  //32
            Boxes.Add(new StreetBox("Green"));  //33
            Boxes.Add(new CommunityBox());      //34
            Boxes.Add(new StreetBox("Green"));  //35
            Boxes.Add(new StationBox());        //36
            Boxes.Add(new ChanceBox());         //37
            Boxes.Add(new StreetBox("Blue"));   //38
            Boxes.Add(new TaxBox());            //39
            Boxes.Add(new StreetBox("Blue"));   //40
             */
        }

    }
}
