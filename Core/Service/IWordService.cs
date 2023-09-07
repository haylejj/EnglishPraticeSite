using Core.Dto;
using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IWordService:IGenericService<Word>
    {
        Task<Word> getLastWord();
    }
}
