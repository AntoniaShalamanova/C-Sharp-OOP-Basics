using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedyTimes
{
    public class Bag
    {
        private Dictionary<string, long> gold;
        private Dictionary<string, long> gem;
        private Dictionary<string, long> cash;

        private long GetGoldAmount()
        {
            return this.Gold.Sum(x => x.Value);
        }

        private long GetGemAmount()
        {
            return this.Gem.Sum(x => x.Value);
        }

        private long GetCashAmount()
        {
            return this.Cash.Sum(x => x.Value);
        }

        public long GetBagAmount()
        {
            return this.Gold.Sum(x => x.Value) +
                this.Gem.Sum(x => x.Value) +
                this.Cash.Sum(x => x.Value);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            if (this.Gold.Count > 0)
            {
                builder.AppendLine($"<Gold> ${this.GetGoldAmount()}");

                builder.Append(PrintItems(this.Gold));
            }

            if (this.Gem.Count > 0)
            {
                builder.AppendLine($"<Gem> ${this.GetGemAmount()}");

                builder.Append(PrintItems(this.Gem));
            }

            if (this.Cash.Count > 0)
            {
                builder.AppendLine($"<Cash> ${this.GetCashAmount()}");

                builder.Append(PrintItems(this.Cash));
            }

            return builder.ToString();
        }

        private string PrintItems(Dictionary<string, long> type)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in type.OrderByDescending(x => x.Key)
                .ThenBy(x => x.Value))
            {
                builder.AppendLine($"##{item.Key} - {item.Value}");
            }

            return builder.ToString();
        }

        internal void GetItem(string item, long amount, string type)
        {
            switch (type)
            {
                case "Gold":
                    if (!this.Gold.ContainsKey(item))
                    {
                        this.Gold[item] = 0;
                    }

                    this.Gold[item] += amount;
                    break;

                case "Gem":
                    if (this.Gold.Count > 0 && this.GetGemAmount() + amount <= this.GetGoldAmount())
                    {
                        if (!this.Gem.ContainsKey(item))
                        {
                            this.Gem[item] = 0;
                        }

                        this.Gem[item] += amount;
                    }
                    break;

                case "Cash":
                    if (this.Gem.Count > 0 && this.GetCashAmount() + amount <= this.GetGemAmount())
                    {
                        if (!this.Cash.ContainsKey(item))
                        {
                            this.Cash[item] = 0;
                        }

                        this.Cash[item] += amount;
                    }
                    break;
            }
        }

        public Bag()
        {
            this.Gold = new Dictionary<string, long>();
            this.Gem = new Dictionary<string, long>();
            this.Cash = new Dictionary<string, long>();
        }

        public Dictionary<string, long> Cash
        {
            get { return cash; }
            set { cash = value; }
        }

        public Dictionary<string, long> Gem
        {
            get { return gem; }
            set { gem = value; }
        }

        public Dictionary<string, long> Gold
        {
            get { return gold; }
            set { gold = value; }
        }
    }
}
