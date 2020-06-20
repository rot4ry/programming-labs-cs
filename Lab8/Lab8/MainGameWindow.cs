using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class MainGameWindow : Form
    {
        private int _ROUND = 0;
        private List<Point> freeSpotsOnTheMap = new List<Point>();

        private List<Human> Humans = new List<Human>();
        private List<Soldier> Soldiers = new List<Soldier>();
        private List<Zombie> Zombies = new List<Zombie>();


        public MainGameWindow()
        {
            InitializeComponent();
        }

        private void SetPointList()
        {
            int PanelSizeX = 420;
            int PanelSizeY = 420;

            for (int i = 0; i <= PanelSizeX - 40; i++)
            {
                for (int j = 0; j <= PanelSizeY - 40; j++)
                {
                    freeSpotsOnTheMap.Add(new Point(i, j));
                }
            }
        }
        private void MainGameWindow_Load(object sender, EventArgs e)
        {
            SetPointList();
        }

        private void nextRoundButton_Click(object sender, EventArgs e)
        {
            _ROUND++;
            roundCounterLabel.Text = _ROUND.ToString();
            
            int panelSizeX = 420;
            int panelSizeY = 420;
            int humanSize = 40;
            int movementRange;
            
            HumansVsZombies();
            HumansVsSoldiers();
            SoldiersVsZombies();

            //MOVE HUMANS
            Random hRand = new Random(new Random().Next(100));
            foreach (Human human in Humans)
            {
                human.isCheckedThisRound = false;

                if (human.Money == (double)0)
                    continue;
                
                else
                {
                    int charX = human.Location.X;
                    int charY = human.Location.Y;
                    int x, y;
                    movementRange = hRand.Next(10, 40);

                    do
                    {
                        x = hRand.Next(-movementRange, movementRange);
                    } while (charX + x < 0 || charX + x > panelSizeX - humanSize);

                    do
                    {
                        y = hRand.Next(-movementRange, movementRange);
                    } while (charY + y < 0 || charY + y > panelSizeY - humanSize);

                    Point newLocation = new Point(charX + x, charY + y);
                    human.MoveTo(newLocation);
                }
            }
            //MOVE SOLDIERS
            Random sRand = new Random(new Random().Next(100));
            foreach (Soldier soldier in Soldiers)
            {

                int charX = soldier.Location.X;
                int charY = soldier.Location.Y;
                int x, y;
                movementRange = sRand.Next(20, 60);

                do
                {
                    x = sRand.Next(-movementRange, movementRange);
                } while (charX + x < 0 || charX + x > panelSizeX - humanSize);

                do
                {
                    y = sRand.Next(-movementRange, movementRange);
                } while (charY + y < 0 || charY + y > panelSizeY - humanSize);

                Point newLocation = new Point(charX + x, charY + y);
                soldier.MoveTo(newLocation);
            }
            //MOVE ZOMBIES
            Random zRand = new Random(new Random().Next(100));
            foreach (Zombie zombie in Zombies)
            {
                int charX = zombie.Location.X;
                int charY = zombie.Location.Y;
                int x, y;
                movementRange = zRand.Next(10, 30);

                do
                {
                    x = zRand.Next(-movementRange, movementRange);
                } while (charX + x < 0 || charX + x > panelSizeX - humanSize);

                do
                {
                    y = zRand.Next(-movementRange, movementRange);
                } while (charY + y < 0 || charY + y > panelSizeY - humanSize);

                Point newLocation = new Point(charX + x, charY + y);
                
                zombie.MoveTo(newLocation);
                zombie.VirusDecrease();

                if (zombie.VirusLeft == 0)
                {
                    Human curedHuman = new Human(zombie.Money, zombie.Coords);
                    curedHuman.MouseEnter += human_MouseEnter;
                    curedHuman.MouseLeave += human_MouseLeave;

                    Humans.Add(curedHuman);
                    
                    zombie.MouseEnter -= zombie_MouseEnter;
                    zombie.MouseLeave -= zombie_MouseLeave;
                    gameMapPanel.Controls.Remove(zombie);
                    gameMapPanel.Controls.Add(curedHuman);
                }
            }

            Zombies = Zombies.Where(x => x.VirusLeft > 0).ToList<Zombie>();
            
            gameMapPanel.Show();
        }
        private void HumansVsZombies()
        {
            int humanSize = 40;
            List<Human> hVz = new List<Human>();

            foreach (Zombie zombie in Zombies)
            {
                int LeftBorder = zombie.Location.X - humanSize + 1;
                int RightBorder = zombie.Location.X + humanSize - 1;
                int TopBorder = zombie.Location.Y - humanSize + 1;
                int BottomBorder = zombie.Location.Y + humanSize - 1;

                foreach (Human human in Humans)
                {
                    int humanX = human.Location.X;
                    int humanY = human.Location.Y;

                    if (
                        Math.Sqrt(
                            Math.Pow((humanX - zombie.Location.X), 2)
                          + Math.Pow((humanY - zombie.Location.Y), 2)) <= 2 * humanSize)
                    {
                        //collision happens
                        if (LeftBorder      <=      humanX &&
                            RightBorder     >=      humanX &&
                            TopBorder       <=      humanY &&
                            BottomBorder    >=      humanY &&
                            human.isInfected == false
                           )
                        {
                            hVz.Add(human);
                            human.isInfected = true;
                        }
                        else 
                            continue;
                    }
                }
            }
                    
            foreach (Human character in hVz)
            {
                Zombie newZombie = new Zombie(character.Money, character.Coords, new Random().NextDouble() * 200, new Random().Next(3,7));
                newZombie.MouseEnter += zombie_MouseEnter;
                newZombie.MouseLeave += zombie_MouseLeave;

                character.MouseEnter -= human_MouseEnter;
                character.MouseLeave -= human_MouseLeave;
                Humans.Remove(character);
                gameMapPanel.Controls.Remove(character);

                Zombies.Add(newZombie);
                gameMapPanel.Controls.Add(newZombie);
            }
            hVz.Clear();
        }
        private void HumansVsSoldiers()
        {
            int humanSize = 40;
            double ticketValue = 100.65;

            List<Human> hVs = new List<Human>();

            foreach (Soldier soldier in Soldiers)
            {
                int LeftBorder      = soldier.Location.X - humanSize + 1;
                int RightBorder     = soldier.Location.X + humanSize - 1;
                int TopBorder       = soldier.Location.Y - humanSize + 1;
                int BottomBorder    = soldier.Location.Y + humanSize - 1;

                foreach (Human human in Humans)
                {
                    int humanX = human.Location.X;
                    int humanY = human.Location.Y;

                    if (
                        Math.Sqrt(
                            Math.Pow((humanX - soldier.Location.X), 2)
                          + Math.Pow((humanY - soldier.Location.Y), 2)) <= 2 * humanSize)
                    {
                        //collision happens
                        if (LeftBorder      <= humanX &&
                            RightBorder     >= humanX &&
                            TopBorder       <= humanY &&
                            BottomBorder    >= humanY &&
                            human.isSoldier == false &&
                            human.isCheckedThisRound == false
                           )
                        {
                            human.isCheckedThisRound = true;
                            if (human.Money >= ticketValue)
                            {
                                human.Money -= ticketValue;
                            }
                            else
                            {
                                human.isSoldier = true;
                                hVs.Add(human);
                            }
                        }
                    }
                }
            }

            foreach (Human character in hVs)
            {
                Soldier newSoldier = new Soldier(character.Money, character.Coords, new Random().NextDouble() * 100);
                newSoldier.MouseEnter += soldier_MouseEnter;
                newSoldier.MouseLeave += soldier_MouseLeave;

                character.MouseEnter -= human_MouseEnter;
                character.MouseLeave -= human_MouseLeave;
                Humans.Remove(character);
                gameMapPanel.Controls.Remove(character);

                Soldiers.Add(newSoldier);
                gameMapPanel.Controls.Add(newSoldier);
            }
        }
        private void SoldiersVsZombies()
        {
            int humanSize = 40;

            List<Soldier> zombified = new List<Soldier>();
            List<Zombie> cured = new List<Zombie>();

            foreach (Soldier soldier in Soldiers)
            {
                int LeftBorder      = soldier.Location.X - humanSize + 1;
                int RightBorder     = soldier.Location.X + humanSize - 1;
                int TopBorder       = soldier.Location.Y - humanSize + 1;
                int BottomBorder    = soldier.Location.Y + humanSize - 1;

                foreach (Zombie zombie in Zombies)
                {
                    int zombieX = zombie.Location.X;
                    int zombieY = zombie.Location.Y;

                    if (
                        Math.Sqrt(
                            Math.Pow((zombieX - soldier.Location.X), 2)
                          + Math.Pow((zombieY - soldier.Location.Y), 2)) <= 2 * humanSize)
                    {
                        //collision happens
                        if (LeftBorder      <= zombieX &&
                            RightBorder     >= zombieX &&
                            TopBorder       <= zombieY &&
                            BottomBorder    >= zombieY) 
                        {
                            if(soldier.Endurance >= zombie.Strength && zombie.isCured == false)
                            {
                                zombie.isCured = true;
                                cured.Add(zombie);
                            }
                            else if(soldier.Endurance < zombie.Strength && soldier.isInfected == false)
                            {
                                soldier.isInfected = true;
                                zombified.Add(soldier);
                            }
                        }
                        else
                            continue;
                    }
                }
            }
            
            foreach (Soldier character in zombified)
            {
                Zombie newZombie = new Zombie(character.Money, character.Coords, new Random().NextDouble() * 200, new Random().Next(3, 7));
                newZombie.MouseEnter += zombie_MouseEnter;
                newZombie.MouseLeave += zombie_MouseLeave;
                
                character.MouseEnter -= soldier_MouseEnter;
                character.MouseLeave -= soldier_MouseLeave;
                Soldiers.Remove(character);
                gameMapPanel.Controls.Remove(character);

                Zombies.Add(newZombie);
                gameMapPanel.Controls.Add(newZombie);
            }
            
            foreach (Zombie character in cured)
            {
                Human curedHuman = new Human(character.Money, character.Coords);
                curedHuman.MouseEnter += human_MouseEnter;
                curedHuman.MouseLeave += human_MouseLeave;

                character.MouseEnter -= zombie_MouseEnter;
                character.MouseLeave -= zombie_MouseLeave;
                Zombies.Remove(character);
                gameMapPanel.Controls.Remove(character);

                Humans.Add(curedHuman);
                gameMapPanel.Controls.Add(curedHuman);
            }
        }

        private void gameResetButton_Click(object sender, EventArgs e)
        {
            humansQTB.Text = "0";
            soldiersQTB.Text = "0";
            zombiesQTB.Text = "0";
            roundCounterLabel.Text = "0";
            _ROUND = 0;

            freeSpotsOnTheMap.Clear();
            Humans.Clear();
            Soldiers.Clear();
            Zombies.Clear();

            gameMapPanel.Controls.Clear();

            SetPointList();
        }

        private void SetAvailableSpots(Point spot)
        {
            /*
            this method prevents characters from colliding on spawn
            results may vary, based on size of the PictureBox (humanSize)
            also, this massively reduces amount of characters (from 170k to ~30-40)
            that can be on the map
            */

            /*
            if you don't care about characters colliding,
            comment this    |
                            V
            */
            int humanSize = 40;
            freeSpotsOnTheMap = freeSpotsOnTheMap
                .Where(x => x.X > (spot.X + humanSize) ||
                            x.Y < (spot.Y - humanSize) ||
                            x.X < (spot.X - humanSize) ||
                            x.Y > (spot.Y + humanSize))
                .ToList<Point>();

            /*
            and uncomment this  |
                                V
            */
            //freeSpotsOnTheMap.Remove(spot);
            /*
             * or don't
             */
        }

        private void addCharactersButton_Click(object sender, EventArgs e)
        {
            int humanQuantity = Convert.ToInt32(humansQTB.Text);
            int soldierQuantity = Convert.ToInt32(soldiersQTB.Text);
            int zombieQuantity = Convert.ToInt32(zombiesQTB.Text);

            Random randomizer = new Random();

            for (int i = 0; i < humanQuantity; i++)
            {
                double money = (double)randomizer.Next(0, 1000);
                Point spot = freeSpotsOnTheMap[randomizer.Next(freeSpotsOnTheMap.Count())];

                SetAvailableSpots(spot);

                Human human = new Human(money, spot);
                human.MouseEnter += human_MouseEnter;
                human.MouseLeave += human_MouseLeave;

                gameMapPanel.Controls.Add(human);
                Humans.Add(human);
            }

            for (int i = 0; i < soldierQuantity; i++)
            {
                double money = (double)randomizer.Next(100, 1000) / randomizer.Next(10, 50);
                Point spot = freeSpotsOnTheMap[randomizer.Next(freeSpotsOnTheMap.Count())];
                double endurance = randomizer.NextDouble() * 100;

                SetAvailableSpots(spot);

                Soldier soldier = new Soldier(money, spot, endurance);
                soldier.MouseEnter += soldier_MouseEnter;
                soldier.MouseLeave += soldier_MouseLeave;

                gameMapPanel.Controls.Add(soldier);
                Soldiers.Add(soldier);
            }

            for (int i = 0; i < zombieQuantity; i++)
            {
                double money = (double)randomizer.Next(100, 1000) / randomizer.Next(10, 50);
                Point spot = freeSpotsOnTheMap[randomizer.Next(freeSpotsOnTheMap.Count())];
                double strength = randomizer.NextDouble() * 200;

                SetAvailableSpots(spot);

                Zombie zombie = new Zombie(money, spot, strength, new Random(new Random().Next(100)).Next(3, 7));
                zombie.MouseEnter += zombie_MouseEnter;
                zombie.MouseLeave += zombie_MouseLeave;
                
                gameMapPanel.Controls.Add(zombie);
                Zombies.Add(zombie);
            }
        }

        private void human_MouseEnter(object sender, EventArgs e)
        {
            Human pointedAt = (Human)sender;
            infoBox.Text =  $"Class:            {pointedAt.GetType().Name}\n" +
                            $"Money:            {pointedAt.Money}\n" +
                            $"Coords:           {pointedAt.Coords.X}/{pointedAt.Coords.Y}";
        }
        private void human_MouseLeave(object sender, EventArgs e)
        {
            infoBox.Text = "";
        }

        private void soldier_MouseEnter(object sender, EventArgs e)
        {
            Soldier pointedAt = (Soldier)sender;
            infoBox.Text =  $"Class:            {pointedAt.GetType().Name}\n" +
                            $"Money:            {pointedAt.Money}\n" +
                            $"Endurance:        {pointedAt.Endurance}\n" +
                            $"Coords:           {pointedAt.Coords.X}/{pointedAt.Coords.Y}";
        }
        private void soldier_MouseLeave(object sender, EventArgs e)
        {
            infoBox.Text = "";
        }

        private void zombie_MouseEnter(object sender, EventArgs e)
        {
            Zombie pointedAt = (Zombie)sender;
            infoBox.Text =  $"Class:            {pointedAt.GetType().Name}\n" +
                            $"Money:            {pointedAt.Money}\n" +
                            $"Strength:         {pointedAt.Strength}\n" +
                            $"Zombie for        {pointedAt.VirusLeft} rounds\n" +
                            $"Coords:           {pointedAt.Coords.X}/{pointedAt.Coords.Y}";
        }
        private void zombie_MouseLeave(object sender, EventArgs e)
        {
            infoBox.Text = "";
        }
    }
}
