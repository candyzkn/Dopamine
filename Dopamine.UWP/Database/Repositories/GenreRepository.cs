﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dopamine.Core.Database;
using Dopamine.Core.Database.Entities;

namespace Dopamine.UWP.Database.Repositories
{
    public class GenreRepository : Core.Database.Repositories.GenreRepository
    {
        #region Construction
        public GenreRepository(ISQLiteConnectionFactory factory) : base(factory)
        {
        }
        #endregion

        #region Overrides
        public override Task<Genre> AddGenreAsync(Genre genre)
        {
            throw new NotImplementedException();
        }

        public override Task<Genre> GetGenreAsync(string genreName)
        {
            throw new NotImplementedException();
        }

        public override Task<List<Genre>> GetGenresAsync()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
