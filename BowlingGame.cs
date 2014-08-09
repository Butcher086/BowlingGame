using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class BowlingGame
    {        
        public int FrameAux { get; set; }                
        public int TotalAux { get; set; }                
        public int strikeFrame { get; set; }
        public bool EndGame { get; set; }

        public Frames[] frames { get; set; }
        public int strikeBonus { get; set; }

        public bool isThirdRoll { get; set; }

        public BowlingGame()
        {
            frames = new Frames[10];
            FrameAux = 0;            
            TotalAux = 0;            
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
        public void rollAux(int pins)
        {
            if (!EndGame)
            {
                AddBonus(pins);
                if (frames[FrameAux].rollI == -1) //Primera tirada
                {
                    if (pins == 10) //Strike
                    {
                        frames[FrameAux].rollI = pins; //Ponemos los bolos derribados en el primer roll
                        frames[FrameAux].total = pins;

                        if (FrameAux == 9)//Si es el Ultimo frame
                        {
                            isThirdRoll = true; //Hay tercera tirada y tambien segunda
                        }
                        else
                        {
                            frames[FrameAux].bonus = 2; //Aplicamos Bonus de Strike
                            FrameAux += 1; //No habrá segunda tirada
                        }
                    }
                    else
                    {
                        frames[FrameAux].rollI = pins; //Ponemos los bolos derribados en el primer roll
                        frames[FrameAux].total = pins;
                    }
                }
                else if (frames[FrameAux].rollII == -1) //segunda tirada
                {
                    frames[FrameAux].rollII = pins;//Ponemos los bolos derribados en el segund roll
                    frames[FrameAux].total += pins;
                    if (IsSpare(FrameAux))//Spare
                    {
                        if (FrameAux == 9) //Si es el ultimo Frame
                        {
                            isThirdRoll = true;
                        }
                        else //Si no es el ultimo frame
                        {
                            frames[FrameAux].bonus += 1; //Aplicamos bonus de Spare
                        }
                    }

                    if ((!isThirdRoll) && (FrameAux == 9)) //Si es el ultimo frame y no hay tercera tirada, se acaba la partida
                    {
                        EndGame = true;
                    }
                    if (FrameAux != 9) //Si no es el ultimo frame, avanzamos
                    {
                        FrameAux += 1; //Avanzamos al siguiente frame
                    }
                }
                else
                {
                    if (isThirdRoll) //tercera tirada del ultimo frame
                    {
                        frames[FrameAux].rollIII = pins;
                        frames[FrameAux].total += pins;
                        EndGame = true;
                    }
                }

            }
        }

        public int scoreAux()
        {
            TotalAux = 0;
            for (int i = 0; i < 10; i++)
            {
                if (frames[i].rollI != -1)
                {
                    TotalAux = TotalAux + frames[i].total;
                }

            }
            return TotalAux;
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
