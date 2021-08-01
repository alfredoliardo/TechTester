import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TestsRoutingModule } from './tests-routing.module';
import { TestsComponent } from './tests.component';
import { TestDashboardComponent } from './test-dashboard/test-dashboard.component';
import { WorkstationDashboardComponent } from './workstation-dashboard/workstation-dashboard.component';
import { TestPlannerComponent } from './test-planner/test-planner.component';
import { TestBranchDashboardComponent } from './test-branch-dashboard/test-branch-dashboard.component';
import { WorkstationTestComponent } from './workstation-test/workstation-test.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    TestsComponent,
    TestDashboardComponent,
    WorkstationDashboardComponent,
    TestPlannerComponent,
    TestBranchDashboardComponent,
    WorkstationTestComponent
  ],
  imports: [
    CommonModule,
    TestsRoutingModule,
    ReactiveFormsModule
  ]
})
export class TestsModule { }
