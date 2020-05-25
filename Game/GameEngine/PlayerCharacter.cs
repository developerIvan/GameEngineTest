using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace GameEngine
{
    public class PlayerCharacter : INotifyPropertyChanged
    {
        private int _health= 100;
       
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<EventArgs> PlayerSlept;

         private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string FirstName { set; get; }

        public string LastName { set; get; }

        public string FullName  => $"{FirstName} {LastName}";

        public string NickName { set; get; }

        public Boolean IsNoob { set; get; } = true;
        
        public List<string> Weapons { set; get; }
        public PlayerCharacter()
        {
            FirstName = GenerateDefaultFirstName();

            IsNoob = true;

            CreateStartingWeapons();

        }


        public int Health
        {

            get => _health;
            set
            {
                _health = value;
                NotifyPropertyChanged();
            }
        }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(1, Health -= damage);
        }
        public void Sleep()
        {
            var healthIncrease = CalculateHealthIncrease();

            _health += healthIncrease;

            OnPlayerSlept(EventArgs.Empty);

        }

        public String GenerateDefaultFirstName()
        {
            return "Squall";
        }

        public void CreateStartingWeapons() {
            Weapons = new List<string>
           {
               "Long Bow",
               "Short Bow",
                "Short Sword",
               // "",
               // " ",
           };
        }

        private int CalculateHealthIncrease()
        {
            var rnd = new Random();

          return rnd.Next(1, 101);
        }

        protected virtual void OnPlayerSlept(EventArgs e)
        {
            PlayerSlept?.Invoke(this, e);
        }


    }
}
