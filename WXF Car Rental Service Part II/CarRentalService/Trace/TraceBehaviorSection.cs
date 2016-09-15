using System;
using System.ServiceModel.Configuration;

namespace CarRentalService.Trace
{
    public class TraceBehaviorSection : BehaviorExtensionElement
    {
        public override Type BehaviorType => typeof(TraceBehavior);

        protected override object CreateBehavior() => new TraceBehavior();
    }
}
