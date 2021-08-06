import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BranchTestStats } from '../_models/branch-test-stats';
import { PaginatedResult } from '../_models/paginated-result';
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

  getBranchTestStats(testId:string, page:number = 1, pageSize:number = 10){
    var params = new HttpParams().set('pageNumber', page).set('pageSize', pageSize);
    console.log(pageSize);
    return this.http.get<PaginatedResult<BranchTestStats>>(this.baseUrl + `grouped/${testId}?${params.toString()}`);
  }
}

