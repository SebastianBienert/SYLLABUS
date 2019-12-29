using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PWRSyllabus.Core.Entities;

namespace PWRSyllabus.Core.Interfaces
{
    public interface IMinisterialEffectRepository
    {
        Task<IEnumerable<MinisterialEffect>> GetAllMinisterialEffects();
        Task<MinisterialEffect> GetMinisterialEffect(int ministerialEffectId);
    }
}
