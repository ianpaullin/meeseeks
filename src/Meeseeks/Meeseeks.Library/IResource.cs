using System;
using System.Collections.Generic;
using System.Text;

namespace Meeseeks.Library
{
    interface IResource
    {
        bool OnPlanned();
        bool OnCreated();
        bool OnDone();
        bool OnReadyToUse();
        bool OnUpdated();
        bool OnFailed();
    }
}
