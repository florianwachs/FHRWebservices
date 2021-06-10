// -----------------------------------------------------------------------
// <copyright file="IStartJobV1.cs" company="Petabridge, LLC">
//      Copyright (C) 2015 - 2019 Petabridge, LLC <https://petabridge.com>
// </copyright>
// -----------------------------------------------------------------------

using Akka.Actor;
using Akka.Routing;
using WebCrawler.Shared.State;

namespace WebCrawler.Shared.Commands.V1
{
    public interface IStartJobV1 : IConsistentHashable
    {
        CrawlJob Job { get; }
        IActorRef Requestor { get; }
    }
}