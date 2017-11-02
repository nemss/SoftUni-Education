namespace _6.FootballTeamGenerator
{
    using System;

    public class Player
    {
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public int Endurance
        {
            get { return this.endurance; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(this.Endurance)} should be between 0 and 100.");
                }
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get { return this.sprint; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(this.Sprint)} should be between 0 and 100.");
                }
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get { return this.dribble; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(this.Dribble)} should be between 0 and 100.");
                }
                this.dribble = value;
            }
        }

        public int Passing
        {
            get { return this.passing; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(this.Passing)} should be between 0 and 100.");
                }
                this.passing = value;
            }
        }

        public int Shooting
        {
            get { return this.shooting; }
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"{nameof(this.Shooting)} should be between 0 and 100.");
                }
                this.shooting = value;
            }
        }

        public int CalculatingAverageSkillPlayer()
        {
            return (int)Math.Round((this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0);
        }


    }
}
