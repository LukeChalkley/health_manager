using System;

namespace proto_model.Domain
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntityId"></typeparam>
    public interface IDomainEntity<out TEntityId> where TEntityId : IEquatable<TEntityId>
    {
        TEntityId ID { get; }
    }
}