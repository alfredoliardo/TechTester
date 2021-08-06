import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { BranchTestStats } from '../_models/branch-test-stats';
import { PaginatedResult } from '../_models/paginated-result';
import { TestsService } from '../_services/tests.service';

@Component({
  selector: 'app-test-dashboard',
  templateUrl: './test-dashboard.component.html',
  styleUrls: ['./test-dashboard.component.scss']
})
export class TestDashboardComponent implements OnInit {

  tests:PaginatedResult<BranchTestStats> = {
    pageSize:0,
    totalPages:0,
    totalItems:0,
    currentPage:0,
    data:[]
  };

  pageSizeOptions = [
    {size:10},
    {size:25},
    {size:50}
  ];


  form = this.fb.group({
    pageSize:this.fb.control(this.pageSizeOptions[0].size)
  });

  testId: string = this.route.snapshot.params.testId;
  page:number = 0;
  pageSize:number = 10;

  constructor(private route:ActivatedRoute,
     private testsService:TestsService,
     private fb:FormBuilder) { 
  }

  ngOnInit(): void {
    this.loadData();
  }

  loadData(page:number = 1, pageSize:number = 10)
  {
    this.testsService.getBranchTestStats(this.testId, page, pageSize).subscribe(response => {
      this.tests = response;
    });
    
  }
  
  pageChanged(event: PageChangedEvent): void {
    this.page = event.page;
    this.loadData(this.page, this.pageSize);
  }

  sizeChanged(){
    console.log(this.form.get('pageSize')?.value);
    this.pageSize = this.form.get('pageSize')?.value;
    this.loadData(this.page, this.pageSize);
  }
  
}
