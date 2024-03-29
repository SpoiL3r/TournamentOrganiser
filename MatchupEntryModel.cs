﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentOrganiserACS
{
    public class MatchupEntryModel
    {
        public int Id { get; set; }
        public TeamModel TeamCompeting { get; set; }
        public double Score { get; set; }
        public MatchupModel ParentMatchup { get; set; }
    }
}
