import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestBranchDashboardComponent } from './test-branch-dashboard/test-branch-dashboard.component';
import { TestDashboardComponent } from './test-dashboard/test-dashboard.component';
import { TestPlannerComponent } from './test-planner/test-planner.component';
import { TestsComponent } from './tests.component';
import { WorkstationDashboardComponent } from './workstation-dashboard/workstation-dashboard.component';
import { WorkstationTestComponent } from './workstation-test/workstation-test.component';

const routes: Routes = [
  { path: 'dashboard', component: WorkstationDashboardComponent },
  { path: ':testId/dashboard', component: TestDashboardComponent},
  { path: ':testId/branch/:bank/:ou/dashboard', component: TestBranchDashboardComponent},
  { path: ':testId/of/:workstation', component: WorkstationTestComponent},
  { path: 'planner', component: TestPlannerComponent},
  { path: '', redirectTo: 'dashboard', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TestsRoutingModule { }
