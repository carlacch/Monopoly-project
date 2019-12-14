using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class FinalBoardGame:BoardGame
    {
        public override void CreateBoxes()
        {
            Boxes.Add(new GoBox()); //1
            Boxes.Add(new stationBox()); //2
            Boxes.Add(new parkingBox()); //3
            Boxes.Add(new chanceBox()); //4
            Boxes.Add(new streetBox()); //5
            Boxes.Add(new communityBox()); //6
            Boxes.Add(new parkingBox()); //7
            Boxes.Add(new stationBox()); //8
            Boxes.Add(new parkingBox()); //9
            Boxes.Add(new parkingBox()); //10
            Boxes.Add(new goToJailBox()); //11
            Boxes.Add(new parkingBox()); //12
            Boxes.Add(new chanceBox()); //13
            Boxes.Add(new streetBox()); //14
            Boxes.Add(new stationBox()); //15
            Boxes.Add(new parkingBox());//16
            Boxes.Add(new taxBox());//17
            Boxes.Add(new parkingBox());//18
            Boxes.Add(new communityBox());//19
            Boxes.Add(new jailBox());//20
            Boxes.Add(new taxBox());//21
            Boxes.Add(new streetBox());//22
            Boxes.Add(new chanceBox());//23
            Boxes.Add(new stationBox());//24
            Boxes.Add(new parkingBox());//25
            Boxes.Add(new communityBox());//26
            Boxes.Add(new streetBox());//27
            Boxes.Add(new parkingBox()); //28
            Boxes.Add(new taxBox());//29
            Boxes.Add(new communityBox());//30
            Boxes.Add(new chanceBox());//31
            Boxes.Add(new streetBox());//32
            Boxes.Add(new parkingBox());//33
            Boxes.Add(new chanceBox());//34
            Boxes.Add(new streetBox()); //35
            Boxes.Add(new parkingBox()); //36
            Boxes.Add(new taxBox()); //37
            Boxes.Add(new communityBox()); //38
            Boxes.Add(new parkingBox()); //39
            Boxes.Add(new taxBox());//40


        }

    }
}
