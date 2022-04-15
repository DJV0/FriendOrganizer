﻿using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Generic;

namespace FriendOrganizer.UI.Data.Repositories
{
    public class MeetingRepository : GenericRepository<Meeting, FriendOrganizerDbContext>, IMeetingRepository
    {
        public MeetingRepository(FriendOrganizerDbContext context) : base(context)
        {
        }
        public override async Task<Meeting> GetByIdAsync(int id)
        {
            return await Context.Meetings
                .Include(m => m.Friends)
                .SingleAsync(m => m.Id == id);
        }
        public async Task<List<Friend>> GetAllFriendsAsync()
        {
            return await Context.Set<Friend>().ToListAsync();
        }
    }
}
