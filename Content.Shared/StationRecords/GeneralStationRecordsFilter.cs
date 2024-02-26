
using Robust.Shared.Serialization;

[Serializable, NetSerializable]
public sealed class AdjustStationJobMsg : BoundUserInterfaceMessage
{
    public string JobProto { get; }
    public int Amount { get; }

    public AdjustStationJobMsg(string jobProto, int amount)
    {
        JobProto = jobProto;
        Amount = amount;
    }
}
