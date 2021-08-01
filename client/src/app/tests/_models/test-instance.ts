import { Check } from "./check";

export interface TestInstance {
    name: string;
    testName: string;
    testStartDate: Date;
    testExpirationDate: Date;
    startTime: Date;
    lastUpdateTime: Date;
    completed: Date;
    damaged: boolean;
    checks: Check[];
    testId: string;
}
