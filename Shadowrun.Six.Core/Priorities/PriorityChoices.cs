using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Shadowrun.Six.Core.Priorities
{
    public class PriorityChoices
    {
        private IPriority? _priorityA;
        private IPriority? _priorityB;
        private IPriority? _priorityC;
        private IPriority? _priorityD;
        private IPriority? _priorityE;

        public IPriority? PriorityA
        {
            get => _priorityA;
            set
            {
                if (value != null && !IsAvailable(value))
                    throw new ArgumentException($"{nameof(PriorityA)}: {value.GetType().Name} is not available.");
                _priorityA = value;
            }
        }
        public IPriority? PriorityB
        {
            get => _priorityB;
            set
            {
                if (value != null && !IsAvailable(value))
                    throw new ArgumentException($"{nameof(PriorityB)}: {value.GetType().Name} is not available.");
                _priorityB = value;
            }
        }
        public IPriority? PriorityC
        {
            get => _priorityC;
            set
            {
                if (value != null && !IsAvailable(value))
                    throw new ArgumentException($"{nameof(PriorityC)}: {value.GetType().Name} is not available.");
                _priorityC = value;
            }
        }
        public IPriority? PriorityD
        {
            get => _priorityD;
            set
            {
                if (value != null && !IsAvailable(value))
                    throw new ArgumentException($"{nameof(PriorityD)}: {value.GetType().Name} is not available.");
                _priorityD = value;
            }
        }
        public IPriority? PriorityE
        {
            get => _priorityE;
            set
            {
                if (value != null && !IsAvailable(value))
                    throw new ArgumentException($"{nameof(PriorityE)}: {value.GetType().Name} is not available.");
                _priorityE = value;
            }
        }

        private bool IsAvailable(IPriority priority)
        {
            return RemainingAvailablePriorities().Any(p => p.GetType() == priority.GetType());
        }

        public List<IPriority> RemainingAvailablePriorities()
        {
            var allPriorities = AllPriorities()
                .Where(a =>
                (_priorityA == null || a.GetType() != _priorityA.GetType())
                && (_priorityB == null || a.GetType() != _priorityB.GetType())
                && (_priorityC == null || a.GetType() != _priorityC.GetType())
                && (_priorityD == null || a.GetType() != _priorityD.GetType())
                && (_priorityE == null || a.GetType() != _priorityE.GetType())
                );
            return allPriorities.ToList();
        }

        public static List<IPriority> AllPriorities()
        {
            return new List<IPriority>
            {
                new AttributePriority(),
                new MagicPriority(),
                new MetaTypePriority(),
                new ResourcesPriority(),
                new SkillPriority()
            };
        }
    }
}
