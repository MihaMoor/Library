namespace Shared.ServiceDefaults.Kafka;

/// <summary>
/// Имена топиков для работы в Kafka.
/// </summary>
public static class TopicNames
{
    /// <summary>
    /// Топик для создания и обновления сущностей между Mesh и Spatial.
    /// </summary>
    public const string BookMagazineUpdateTopic =
#if DEBUG
        "testUpdate";
#else
        "BookMagazineUpdate";
#endif

    /// <summary>
    /// Топик для удаления сущностей между Mesh и Spatial.
    /// </summary>
    public const string BookMagazineDeleteTopic =
#if DEBUG
        "testDelete";
#else
        "BookMagazineDelete";
#endif
}