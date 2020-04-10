using System;
using System.Collections.Generic;

namespace Hackathon
{
    abstract class Human
    {
        private string name;
        private int maxHealth;
        private int currentHealth;
        private int maxStrength;
        private int currentStrength;
        private int maxDexterity;
        private int currentDexterity;
        private int maxIntelligence;
        private int currentIntelligence;



        public string Name 
        {
            get { return name; }
        }
        public int MaxHealth
        {
            get { return maxHealth; }
        }
        public int CurrentHealth
        {
            get { return currentHealth; }
        }
        public int MaxStrength
        {
            get { return maxStrength; }
        }
        public int CurrentStrength
        {
            get { return currentStrength; }
        }
        public int MaxDexterity
        {
            get { return maxDexterity; }
        }
        public int CurrentDexterity
        {
            get { return currentDexterity; }
        }
        public int MaxIntelligence
        {
            get { return maxIntelligence; }
        }
        public int CurrentIntelligence
        {
            get { return currentIntelligence; }
        }

        public Human(string name)
        {
            this.name = name;

            this.maxHealth = 100;
            this.currentHealth = this.maxHealth;

            this.maxStrength = 3;
            this.currentStrength = this.maxStrength;

            this.maxDexterity = 3;
            this.currentDexterity = this.maxDexterity;

            this.maxIntelligence = 3;
            this.currentIntelligence = this.maxIntelligence;
        }
        public Human(string name, int h, int s, int d, int i)
        {
            this.name = name;

            this.maxHealth = 100;
            this.currentHealth = this.maxHealth;

            this.maxStrength = 3;
            this.currentStrength = this.maxStrength;

            this.maxDexterity = 3;
            this.currentDexterity = this.maxDexterity;

            this.maxIntelligence = 3;
            this.currentIntelligence = this.maxIntelligence;
        }

        public virtual void Speak()
        {
            System.Console.WriteLine("Hi!");
        }

    }
}