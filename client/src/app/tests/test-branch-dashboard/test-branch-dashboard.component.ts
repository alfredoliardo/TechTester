import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TestsService } from '../_services/tests.service';

@Component({
  selector: 'app-test-branch-dashboard',
  templateUrl: './test-branch-dashboard.component.html',
  styleUrls: ['./test-branch-dashboard.component.scss']
})
export class TestBranchDashboardComponent implements OnInit {

  testId:string = this.route.snapshot.params.testId;
  bank:string = this.route.snapshot.params.bank;
  ou:string = this.route.snapshot.params.ou;
  

  constructor(private route:ActivatedRoute, private testsService:TestsService) { }

  ngOnInit(): void {

  }

}
