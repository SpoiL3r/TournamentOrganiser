using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganiserACS
{
    public class MatchupModel
    {
        public int Id { get; set; }
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        public TeamModel Winner { get; set; }
        public int MatchupRound { get; set; }

        public string DisplayName
        {
            get
            {
                string output = "";
                foreach (MatchupEntryModel me in Entries)
                {
                    if(output.Length == 0)
                    {
                        if(me.TeamCompeting != null)
                        {
                            output = me.TeamCompeting.TeamName;
                        }
                    }
                    else
                    {
                        output += $" vs. {me.TeamCompeting.TeamName}";
                    }
                }
                return output;
            }
        }
    }
}
