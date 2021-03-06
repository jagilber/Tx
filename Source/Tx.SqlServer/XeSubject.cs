﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Reactive.Subjects;
using Microsoft.SqlServer.XEvent;
using Microsoft.SqlServer.XEvent.Linq;

namespace Tx.SqlServer
{
    public abstract class XeSubject : IXETarget, IObservable<PublishedEvent>
    {
        protected abstract Subject<PublishedEvent> Instance { get; }

        // how to get OnCompleted and OnError?

        public IDisposable Subscribe(IObserver<PublishedEvent> observer)
        {
            return Instance.Subscribe(observer);
        }

        public override void ProcessEvent(PublishedEvent eventToProcess)
        {
            Instance.OnNext(eventToProcess);
        }
    }
}