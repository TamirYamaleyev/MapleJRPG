using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Core
{
    internal interface IDamageable
    {
        string Name { get; }
        bool IsAlive { get; }
        int MaxHealth { get; }
        int CurrentHealth { get; }
        void TakeDamage(int damage);
        void Heal(int amount);
        int NormalAttack(IDamageable target);
    }
}
