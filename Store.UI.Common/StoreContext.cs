using Store.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UI.Common
{
    public class StoreContext
    {
        public MovieCollection Movies { get; set; } 

        public MemberCollection Members { get; set; }

        public TopMovieQueue TopMovies { get; set; }

       
        private Member _member;

        public void SetActiveMember(Member member)
        {
            _member = member;
        }
        public Member GetMember()
        {
            return _member;
        }

    }
}
