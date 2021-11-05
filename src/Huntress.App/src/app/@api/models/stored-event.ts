export type StoredEvent = {
    storedEventId: string,
    streamId: string,
    type: string,
    aggregate: string,
    aggregateDotNetType: string,
    sequence: number,
    data: string,
    dotNetType: string,
    version: number,
    correlationId: string,
};
