import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BranchTestStats } from '../_models/branch-test-stats';
import { TestsService } from '../_services/tests.service';

@Component({
  selector: 'app-test-dashboard',
  templateUrl: './test-dashboard.component.html',
  styleUrls: ['./test-dashboard.component.scss']
})
export class TestDashboardComponent implements OnInit {

  tests:BranchTestStats[] | null = null;

  constructor(private route:ActivatedRoute, private testsService:TestsService) { }

  ngOnInit(): void {
    var testId = this.route.snapshot.params.testId;
    this.testsService.getBranchTestStats(testId).subscribe(response => {
      this.tests = response;
    });
  }

}
