using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Core
{
    internal interface IDamageable
    {
        bool IsAlive { get; }
        int MaxHealth { get; }
        int CurrentHealth { get; }
        void TakeDamage(int damage);
        void Heal(int amount);
        void NormalAttack(IDamageable target);
    }
}
