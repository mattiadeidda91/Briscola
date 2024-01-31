using System.Collections.Generic;

namespace Briscola
{
    public class Card
    {
        #region Membri

        private readonly int _number;
        private readonly string _seed; 
        private int _value;
        private readonly string _imageLocation;

        #endregion

        #region Constructor

        public Card(string path)
        {
            _imageLocation = path;
            _number = SetCardNumber(path);
            _seed = SetCardSeed(path);
            _value = SetCardValue(path);
        }

        #endregion

        #region Properties

        public string Path
        {
            get { return _imageLocation; }
        }

        public int Number
        {
            get { return _number; }
        }

        public string Seed
        {
            get { return _seed; }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        #endregion

        #region Functions

        private string SetCardSeed(string path)
        {
            Dictionary<string, string> seedMappings = new Dictionary<string, string>
            {
                { "Bastoni", "bastoni" },
                { "Coppe", "coppe" },
                { "Denari", "denari" },
            };

            foreach (var mapping in seedMappings)
            {
                if (path.Contains(mapping.Key))
                {
                    return mapping.Value;
                }
            }

            return "spade";
        }

        private int SetCardValue(string path)
        {
            Dictionary<string, int> valueMappings = new Dictionary<string, int>
            {
                { "asso", 11 },
                { "tre", 10 },
                { "re", 4 },
                { "cavallo", 3 },
                { "donna", 2 },
            };

            foreach (var mapping in valueMappings)
            {
                if (path.Contains(mapping.Key))
                {
                    return mapping.Value;
                }
            }

            return 0;
        }

        private int SetCardNumber(string path)
        {
            Dictionary<string, int> numberMappings = new Dictionary<string, int>
            {
                { "asso", 1 },
                { "due", 2 },
                { "tre", 3 },
                { "quattro", 4 },
                { "cinque", 5 },
                { "sei", 6 },
                { "sette", 7 },
                { "donna", 8 },
                { "cavallo", 9 },
            };

            foreach (var mapping in numberMappings)
            {
                if (path.Contains(mapping.Key))
                {
                    return mapping.Value;
                }
            }

            return 10;
        }

        #endregion
    }
}
