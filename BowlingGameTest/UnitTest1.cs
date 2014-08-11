using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame;

namespace BowlingGameTest
{
    [TestClass]
    public class UnitTest1
    {        
        
        //Tiradas Normales

        [TestMethod] 

        public void TiradaNormal()
        {
            BowlingGame.BowlingGame b = new BowlingGame.BowlingGame();

            b.roll(3);
            b.roll(4);
            Assert.AreEqual(b.score(), 7);
        }

        [TestMethod]

        public void VariasTiradasNormales()
        {
            BowlingGame.BowlingGame b = new BowlingGame.BowlingGame();
            //Primera tirada
            b.roll(3);
            Assert.AreEqual(b.frames[0].rollI, 3);
            b.roll(4);
            Assert.AreEqual(b.frames[0].rollII, 4);
            Assert.AreEqual(b.score(), 7); //El total del frame 0 es 7
            //Segunda tirada            
            b.roll(9);
            Assert.AreEqual(b.frames[1].rollI, 9);           
            b.roll(0);
            Assert.AreEqual(b.frames[1].rollII, 0);
            Assert.AreEqual(b.frames[1].total, 9); //El total del Frame 1 es 9
            //Assert.AreEqual(b.scoreAux(), 16);
            //Tercera Tirada
            b.roll(0);
            b.roll(6);
            Assert.AreEqual(b.frames[2].total, 6); //El total del frame 3 es 6
            //Assert.AreEqual(b.scoreAux(), 22);            
        }

        //Strikes
        [TestMethod]

        public void StrikeUnoSolo()
        {
            BowlingGame.BowlingGame b = new BowlingGame.BowlingGame();
            //Strike
            b.roll(10);
            //Tirada 1, frame 1 con bonus de strike
            b.roll(3);
            //Tirada 2, frame 1 con bonus de strike
            b.roll(2);
            Assert.AreEqual(b.frames[0].total + b.frames[1].total, 20);
        }

        [TestMethod]

        public void StrikeMultiples()
        {
            BowlingGame.BowlingGame b = new BowlingGame.BowlingGame();
            //Strike
            b.roll(10);
            b.roll(10);
            b.roll(10);            
            Assert.AreEqual(b.score(), 60);

            b.roll(8);
            b.roll(0);
            Assert.AreEqual(b.score(),84);

            b.roll(10);
            
            b.roll(1);
            b.roll(5);
            Assert.AreEqual(b.score(), 106);
        }

        //Spares

        [TestMethod]

        public void SpareUnico()
        {
            BowlingGame.BowlingGame b = new BowlingGame.BowlingGame();

            //Spare
            b.roll(4);
            b.roll(6);

            b.roll(3);
            b.roll(1);
            Assert.AreEqual(b.score(),17);
        }

        [TestMethod]

        public void SpareMultiples()
        {
            BowlingGame.BowlingGame b = new BowlingGame.BowlingGame();

            //Tirada 1
            b.roll(7);
            b.roll(1);

            //Tirada 2 Spare
            b.roll(8);
            b.roll(2);

            //Tirada 3 Spare
            b.roll(5);
            b.roll(5);

            //Tirada 4
            b.roll(3);
            b.roll(4);

            //Tirada 5 Spare
            b.roll(9);
            b.roll(1);

            //Tirada 6
            b.roll(7);
            b.roll(1);

            Assert.AreEqual(b.score(),68);
        }

        //Strike y Spare

        [TestMethod]

        public void StrikesYSpares()
        {
            BowlingGame.BowlingGame b = new BowlingGame.BowlingGame();

            //Tirada 1
            b.roll(4);
            b.roll(3);

            //Tirada 2 Strike
            b.roll(10);

            //Tirada 3 Spare
            b.roll(8);
            b.roll(2);

            Assert.AreEqual(b.score(), 37);

            //Tirada 4 Strike
            b.roll(10);

            Assert.AreEqual(b.score(), 57);

            //Tirada 5
            b.roll(2);
            b.roll(5);

            //Tirada 6 Spare
            b.roll(9);
            b.roll(1);

            //Tirada 7
            b.roll(3);
            b.roll(3);

            Assert.AreEqual(b.score(),90);
        }

        //Tirada 10

        [TestMethod]

        public void TiradaNormalDecimo()
        {
            BowlingGame.BowlingGame b = new BowlingGame.BowlingGame();

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            //tirada 10
            b.roll(1);
            b.roll(4);
            Assert.AreEqual(b.score(), 5);
        }

        [TestMethod]

        public void StrikeDecimaTirada()
        {
            BowlingGame.BowlingGame b = new BowlingGame.BowlingGame();

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            //tirada 10
            b.roll(10);
            b.roll(4);
            b.roll(6);
            Assert.AreEqual(b.score(), 20);
        }

        [TestMethod]

        public void SpareDecimaTirada()
        {
            BowlingGame.BowlingGame b = new BowlingGame.BowlingGame();

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            //tirada 10
            b.roll(2);
            b.roll(8);
            b.roll(6);
            Assert.AreEqual(b.score(), 16);
        }
        
        [TestMethod]

        public void FramePerfectoDecimo()
        {
            BowlingGame.BowlingGame b = new BowlingGame.BowlingGame();

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            b.roll(0);
            b.roll(0);

            //tirada 10
            b.roll(10);
            b.roll(10);
            b.roll(10);
            Assert.AreEqual(b.score(), 30);
        }

        //Jugadas

        [TestMethod]

        public void GutterGame()
        {
            BowlingGame.BowlingGame b = new BowlingGame.BowlingGame();
            
            for (int i=0; i<12; i++)
            {
                b.roll(0);
            }

            Assert.AreEqual(b.score(), 0);
        }

        [TestMethod]

        public void PerfectGame()
        {
            BowlingGame.BowlingGame b = new BowlingGame.BowlingGame();

            for (int i=0; i<12; i++)
            {
                b.roll(10);
            }            

            Assert.AreEqual(b.score(), 300);
        }

        [TestMethod]

        public void EjemploCompleto()
        {
            BowlingGame.BowlingGame b = new BowlingGame.BowlingGame();
            //Frame 1
            b.roll(1);
            b.roll(4);
            //Frame 2
            b.roll(4);
            b.roll(5);
            //Frame 3
            b.roll(6);
            b.roll(4);
            //Frame 4
            b.roll(5);
            b.roll(5);
            //Frame 5
            b.roll(10);
            
            //Frame 6
            b.roll(0);
            b.roll(1);
            //Frame 7
            b.roll(7);
            b.roll(3);
            //Frame 8
            b.roll(6);
            b.roll(4);
            //Frame 9
            b.roll(10);
            
            //Frame 10
            b.roll(2);
            b.roll(8);
            b.roll(6);

            Assert.AreEqual(b.score(),133);
        }

        //Otros

        [TestMethod]

        public void NoSalirDeRango()
        {
            BowlingGame.BowlingGame b = new BowlingGame.BowlingGame();

            b.roll(11);
            Assert.AreEqual(b.score(), 0);
            Assert.AreEqual(b.Frame, 0);

            b.roll(-5);
            Assert.AreEqual(b.score(), 0);
            Assert.AreEqual(b.Frame, 0);

            b.roll(3);
            b.roll(4);
            Assert.AreEqual(b.score(), 7);
            Assert.AreEqual(b.Frame, 1);

            b.roll(34);
            Assert.AreEqual(b.score(), 7);
            Assert.AreEqual(b.Frame, 1);
        }

        [TestMethod]

        public void ComprobarEndGame()
        {
            BowlingGame.BowlingGame b = new BowlingGame.BowlingGame();

            Assert.IsFalse(b.isThirdRoll);
            Assert.IsFalse(b.EndGame);

            for (int i = 0; i < 12; i++)
            {
                b.roll(10);
            }

            Assert.IsTrue(b.isThirdRoll);
            Assert.IsTrue(b.EndGame);

            //Despues de terminar la partida, no se suma ningun punto mas
            b.roll(5);

            Assert.AreEqual(b.score(), 300);
        }
    }
}
