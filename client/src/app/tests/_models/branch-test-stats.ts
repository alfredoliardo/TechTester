export interface BranchTestStats {
    groupName: string;
    bank: string;
    ou: string;
    info: string;
    lastUpdateTime?: Date;
    workstations: number;
    notStarted: number;
    running: number;
    completed: number;
    damaged: number;
    withNegativeResponses: number;
    status: number;
}
