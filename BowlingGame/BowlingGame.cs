using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class BowlingGame
    {        
        public int Frame { get; set; }                
        public int Total { get; set; }                
        public int strikeFrame { get; set; }
        public bool EndGame { get; set; }

        public Frames[] frames { get; set; }
        public int strikeBonus { get; set; }

        public bool isThirdRoll { get; set; }

        public BowlingGame()
        {
            frames = new Frames[10];
            Frame = 0;            
            Total = 0;            
            strikeFrame = 0;
            EndGame = false;            
            strikeBonus = 0;
            isThirdRoll = false;
            InicializeFrames();
        }

        private void InicializeFrames()
        {
            for (int i = 0; i < 10; i++)
            {
                Frames f = new Frames();
                f.rollI = -1;
                f.rollII = -1;
                f.rollIII = -1;
                f.framePosition = i;
                frames[i] = f;
            }
        }
        public void roll(int pins)
        {
            if ((!EndGame) && (pins <= 10) && (pins >= 0)) //Si no se ha completado todos los frames, y si no se sale de rango
            {
                AddBonus(pins);//Añadir bonus
                if (frames[Frame].rollI == -1) //Primera tirada
                {
                    if (pins == 10) //Strike
                    {
                        frames[Frame].rollI = pins; //Ponemos los bolos derribados en el primer roll
                        frames[Frame].total = pins;

                        if (Frame == 9)//Si es el Ultimo frame
                        {
                            isThirdRoll = true; //Hay tercera tirada y tambien segunda
                        }
                        else
                        {
                            frames[Frame].bonus = 2; //Aplicamos Bonus de Strike
                            Frame += 1; //No habrá segunda tirada
                        }
                    }
                    else
                    {
                        frames[Frame].rollI = pins; //Ponemos los bolos derribados en el primer roll
                        frames[Frame].total = pins;
                    }
                }
                else if (frames[Frame].rollII == -1) //segunda tirada
                {
                    frames[Frame].rollII = pins;//Ponemos los bolos derribados en el segund roll
                    frames[Frame].total += pins;
                    if (IsSpare(Frame))//Spare
                    {
                        if (Frame == 9) //Si es el ultimo Frame
                        {
                            isThirdRoll = true;
                        }
                        else //Si no es el ultimo frame
                        {
                            frames[Frame].bonus += 1; //Aplicamos bonus de Spare
                        }
                    }

                    if ((!isThirdRoll) && (Frame == 9)) //Si es el ultimo frame y no hay tercera tirada, se acaba la partida
                    {
                        EndGame = true;
                    }
                    if (Frame != 9) //Si no es el ultimo frame, avanzamos
                    {
                        Frame += 1; //Avanzamos al siguiente frame
                    }
                }
                else
                {
                    if (isThirdRoll) //tercera tirada del ultimo frame
                    {
                        frames[Frame].rollIII = pins;
                        frames[Frame].total += pins;
                        EndGame = true;
                    }
                }

            }
        }

        public int score()
        {
            Total = 0;
            for (int i = 0; i < 10; i++)
            {
                if (frames[i].rollI != -1)
                {
                    Total = Total + frames[i].total;
                }

            }
            return Total;
        }

        private void AddBonus(int pins) //Suma el bonus con los bolos tirados para ese roll
        {
            for (int i = 0; i < 10; i++)
            {
                if (frames[i].bonus > 0)
                {
                    frames[i].total += pins;
                    frames[i].bonus -= 1;
                }
            }
        }

        private bool IsSpare(int f) //Dice si hay un Spare o no
        {
            if ((frames[f].rollI + frames[f].rollII) == 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }     
}
