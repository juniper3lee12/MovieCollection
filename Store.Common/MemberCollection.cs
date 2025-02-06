using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common
{
    public class MemberCollection
    {
        private Member[] _members;
        private int _memberCount;
        private int _currentIndex;

        public MemberCollection(int memberCount)
        {
            _memberCount = memberCount;
            _members = new Member[_memberCount];
            _currentIndex = 0;
        }

        public void AddMember(Member member)
        {
            _members[_currentIndex] = member;
            _currentIndex++;
        }

        public void RemoveMember(Member member) { 
            for(var i=0;i<_currentIndex; i++)
            {
                var currentMember = _members[i];
                if (currentMember.IsEqual(member))
                {
                    ShiftMembers(i);
                    _currentIndex--;
                    return;
                }
            }
        }

        public Member FindMember(Member member)
        {
            Member found = null;
            for (int i = 0; i < _currentIndex; i++)
            {
                if (_members[i].IsEqual(member))
                {
                    found= _members[i];
                    break;
                }
            }
            return found;
        }

        public string FindMembersByMovie(string movieName)
        {
            var report = "";
            for (int i = 0; i < _currentIndex; i++)
            {
                var movies = _members[i].GetBurrowedMovies();
                var found = movies.Find(new Movie(movieName));
                if (found != null)
                {
                    report += $"{_members[i].FirstName} {_members[i].LastName}\r\n";
                }
            }
            return report;
        }

        private void ShiftMembers(int startIndex)
        {
            for(var i=startIndex; i<_currentIndex-1; i++)
            {
                _members[i] = _members[i+1];
            }
        }
        
    }
}
