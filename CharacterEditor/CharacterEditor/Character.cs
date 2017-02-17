using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CharacterEditor
{
    public struct Defense
    {
        private decimal armor;

        public decimal Armor
        {
            get { return armor; }
            set { armor = value; }
        }
        private decimal block;

        public decimal Block
        {
            get { return block; }
            set { block = value; }
        }
        private decimal resilience;

        public decimal Resilience
        {
            get { return resilience; }
            set { resilience = value; }
        }
        private decimal dodge;

        public decimal Dodge
        {
            get { return dodge; }
            set { dodge = value; }
        }
        private decimal parry;

        public decimal Parry
        {
            get { return parry; }
            set { parry = value; }
        }
    }

    public struct Melee
    {
        private decimal damage;

        public decimal Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        private decimal expertise;

        public decimal Expertise
        {
            get { return expertise; }
            set { expertise = value; }
        }
        private decimal hitRating;

        public decimal HitRating
        {
            get { return hitRating; }
            set { hitRating = value; }
        }
        private decimal power;

        public decimal Power
        {
            get { return power; }
            set { power = value; }
        }
        private decimal speed;

        public decimal Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        private decimal weaponSkill;

        public decimal WeaponSkill
        {
            get { return weaponSkill; }
            set { weaponSkill = value; }
        }
    }

    public struct Spell
    {
        private decimal bonusDamage;

        public decimal BonusDamage
        {
            get { return bonusDamage; }
            set { bonusDamage = value; }
        }
        private decimal bonusHealing;

        public decimal BonusHealing
        {
            get { return bonusHealing; }
            set { bonusHealing = value; }
        }
        private decimal hasteRating;

        public decimal HasteRating
        {
            get { return hasteRating; }
            set { hasteRating = value; }
        }
        private decimal hitRating;

        public decimal HitRating
        {
            get { return hitRating; }
            set { hitRating = value; }
        }
        private decimal mana;

        public decimal Mana
        {
            get { return mana; }
            set { mana = value; }
        }
        private decimal penetration;

        public decimal Penetration
        {
            get { return penetration; }
            set { penetration = value; }
        }
    }

    public class Character
    {
        //Fields/Data members
        private decimal agility;

        public decimal Agility
        {
            get { return agility; }
            set { agility = value; }
        }
        private decimal intellect;

        public decimal Intellect
        {
            get { return intellect; }
            set { intellect = value; }
        }
        private decimal strength;

        public decimal Strength
        {
            get { return strength; }
            set { strength = value; }
        }
        private decimal stamina;

        public decimal Stamina
        {
            get { return stamina; }
            set { stamina = value; }
        }
        private decimal spirit;

        public decimal Spirit
        {
            get { return spirit; }
            set { spirit = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string placeOfBirth;

        public string PlaceOfBirth
        {
            get { return placeOfBirth; }
            set { placeOfBirth = value; }
        }

        Melee meleeAttributes;

        public Melee MeleeAttributes
        {
            get { return meleeAttributes; }
            set { meleeAttributes = value; }
        }

        Defense defenseAttributes;

        public Defense DefenseAttributes
        {
            get { return defenseAttributes; }
            set { defenseAttributes = value; }
        }

        Spell spellAttributes;

        public Spell SpellAttributes
        {
            get { return spellAttributes; }
            set { spellAttributes = value; }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
