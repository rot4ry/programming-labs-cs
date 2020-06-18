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


            //MANAGE HUMANS
            Random hRand = new Random(new Random().Next(100));
            foreach (Human human in Humans)
            {
                if (human.Money == (double)0)
                    continue;

                else
                {
                    int charX = human.Location.X;
                    int charY = human.Location.Y;
                    int x, y;
                    movementRange = hRand.Next(50, 100);

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

            //MANAGE SOLDIERS
            Random sRand = new Random(new Random().Next(100));
            foreach (Soldier soldier in Soldiers)
            {
                int charX = soldier.Location.X;
                int charY = soldier.Location.Y;
                int x, y;
                movementRange = sRand.Next(70, 120);

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

            //MANAGE ZOMBIES
            Random zRand = new Random(new Random().Next(100));
            foreach (Zombie zombie in Zombies)
            {
                int charX = zombie.Location.X;
                int charY = zombie.Location.Y;
                int x, y;
                movementRange = zRand.Next(20, 50);

                do
                {
                    x = zRand.Next(-movementRange, movementRange);
                } while (charX + x < 0 || charX + x > panelSizeX - humanSize);

                do
                {
                    y = zRand.Next(-movementRange, movementRange);
                } while (charY + y < 0 || charY + y > panelSizeY - humanSize);

                Point newLocation = new Point(charX + x, charY + y);
                zombie.VirusDecrease();
                Console.WriteLine(zombie.VirusLeft);
                
                if(zombie.VirusLeft == 0)
                {
                    Human curedHuman = new Human(zombie.Money, zombie.Coords);
                    Humans.Add(curedHuman);

                    gameMapPanel.Controls.Remove(zombie);
                    gameMapPanel.Controls.Add(curedHuman);
                }
                
                else 
                    zombie.MoveTo(newLocation);
            }

            Zombies = Zombies.Where(x => x.VirusLeft > 0).ToList<Zombie>();

            gameMapPanel.Show();
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
        }

        private void addCharactersButton_Click(object sender, EventArgs e)
        {
            int humanQuantity = Convert.ToInt32(humansQTB.Text);
            int soldierQuantity = Convert.ToInt32(soldiersQTB.Text);
            int zombieQuantity = Convert.ToInt32(zombiesQTB.Text);

            Random randomizer = new Random();
            
            for(int i = 0; i < humanQuantity; i++)
            {
                double money = (double)randomizer.Next(0, 1000);
                Point spot = freeSpotsOnTheMap[randomizer.Next(freeSpotsOnTheMap.Count())];

                SetAvailableSpots(spot);

                Human human = new Human(money, spot);
                gameMapPanel.Controls.Add(human);
                Humans.Add(human);
            }
               
            for(int i = 0; i < soldierQuantity; i++)
            {
                double money = (double)randomizer.Next(100, 1000) / randomizer.Next(10, 50);
                Point spot = freeSpotsOnTheMap[randomizer.Next(freeSpotsOnTheMap.Count())];
                double endurance = randomizer.NextDouble() * 100;

                SetAvailableSpots(spot);

                Soldier soldier = new Soldier(money, spot, endurance);
                gameMapPanel.Controls.Add(soldier);
                Soldiers.Add(soldier);
            }

            for(int i = 0; i < zombieQuantity; i++)
            {
                double money = (double)randomizer.Next(100, 1000) / randomizer.Next(10, 50);
                Point spot = freeSpotsOnTheMap[randomizer.Next(freeSpotsOnTheMap.Count())];
                double strength  = randomizer.NextDouble() * 200;
                
                SetAvailableSpots(spot);

                Zombie zombie = new Zombie(money, spot, strength, new Random(new Random().Next(100)).Next(3, 7));
                gameMapPanel.Controls.Add(zombie);
                Zombies.Add(zombie);
            }
        }
    }
}
