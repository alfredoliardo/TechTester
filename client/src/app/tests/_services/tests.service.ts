import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BranchTestStats } from '../_models/branch-test-stats';
import { TestInstance } from '../_models/test-instance';

@Injectable({
  providedIn: 'root'
})
export class TestsService {
  baseUrl = "http://localhost:5000/api/tests/";

  constructor(private http:HttpClient) { }

  getWorkstationTests(workstationName:string){
    return this.http.get<TestInstance[]>(this.baseUrl + `for/${workstationName}`);
  }

  getWorkstationTest(testId:string, workstationName:string){
    return this.http.get<TestInstance>(this.baseUrl + `${testId}/of/${workstationName}`);
  }

  getBranchTestStats(testId:string){
    return this.http.get<BranchTestStats[]>(this.baseUrl + `grouped/${testId}`);
  }
}

