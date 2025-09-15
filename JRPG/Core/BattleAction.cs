using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Core
{
    internal class BattleAction
    {
        public enum ActionType
        {
            Attack,
            Skill,
            Item,
            Defend,
        }
        public IDamageable Actor { get; set; }
        public ActionType Type { get; set; }
        public List<IDamageable> Targets { get; private set; } = new();
        public int ResultValue { get; set; }
        public Skill Skill { get; set; }

        public void SetSingleTarget(IDamageable target)
        {
            Targets.Clear();
            Targets.Add(target);
        }

        public BattleAction(IDamageable actor, ActionType action)
        {
            Actor = actor;
            Type = action;
        }
        public BattleAction(IDamageable actor, ActionType action, IDamageable target)
        {
            Actor = actor;
            Type = action;
            SetSingleTarget(target);
        }
        public BattleAction(IDamageable actor, Skill skill, IDamageable target)
        {
            Actor = actor;
            Type = ActionType.Skill;
            Skill = skill;
            SetSingleTarget(target);
        }
        public BattleAction(IDamageable actor, Skill skill)
        {
            Actor = actor;
            Type = ActionType.Skill;
            Skill = skill;
        }
    }
}
