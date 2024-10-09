using System.Collections.Generic;

namespace Assets.Script
{
    public class PlayerData
    {

        public Dictionary<string, string> dicPlayerName = new Dictionary<string, string>();
        public Dictionary<string, int> dicCoins = new Dictionary<string, int>();
        public Dictionary<string, PlayerBuy> dicPlayerBuy = new Dictionary<string, PlayerBuy>();
        public Dictionary<string, int> dicHighScore = new Dictionary<string, int>();
        public Dictionary<string, bool> coinAchivement = new Dictionary<string, bool>();



    }
}
