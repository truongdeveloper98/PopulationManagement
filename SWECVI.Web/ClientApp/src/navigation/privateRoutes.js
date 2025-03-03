/** 
  All of the routes for the Otis Admin PRO React are added here,
  You can add a new route, customize the routes and delete the routes here.

  Once you add a new route on this file it will be visible automatically on
  the Sidenav.

  For adding a new route you can follow the existing routes in the routes array.
  1. The `type` key with the `collapse` value is used for a route.
  2. The `type` key with the `title` value is used for a title inside the Sidenav. 
  3. The `type` key with the `divider` value is used for a divider between Sidenav items.
  4. The `name` key is used for the name of the route on the Sidenav.
  5. The `key` key is used for the key of the route (It will help you with the key prop inside a loop).
  6. The `icon` key is used for the icon of the route on the Sidenav, you have to add a node.
  7. The `collapse` key is used for making a collapsible item on the Sidenav that contains other routes
  inside (nested routes), you need to pass the nested routes inside an array as a value for the `collapse` key.
  8. The `route` key is used to store the route location which is used for the react router.
  9. The `href` key is used to store the external links location.
  10. The `title` key is only for the item with the type of `title` and its used for the title text on the Sidenav.
  10. The `component` key is used to store the component of its route.
*/

// import ProfileOverview from "features/profile";
import Patients from "features/patients";
import Users from "features/users";
import UserDetail from "features/user-detail";
import Icon from "@mui/material/Icon";
import Analytics from "features/analytics";
import UserName from "features/profile/components/UserName";
import Statistics from "features/statistics";
import ExamDetail from "features/exam-detail";
// import Sessions from "features/sessions";
// import Parameters from "features/parameters";
import Python from "features/python";
import PatientFinding from "features/patient-finding";
import Hospital from "features/hospital";
import HospitalDetail from "features/hospital-detail";
import Department from "features/department";
import DepartmentDetail from "features/department-detail";
import References from "features/references";
import ReferencesDetail from "features/references-detail";
// import ManufacturerDicom from "features/manufacturer-dicom";
import ManufacturerDicomDetail from "features/manufacturer-dicom-detail";
// import ExportData from "features/export-data";
import Assessment from "features/assessment";
import Job from "features/job";
import AssessmentDetail from "features/assessment-detail";
import ParameterSettings from "features/settings";
import ParameterSettingsDetail from "features/settings-detail";
import FindingStructure from "features/finding-structure";
import FindingDetail from "features/findings-detail";
import PAGES from "./pages";
import JobDetail from "features/job-detail";
import Company from "features/company";
import CompanyDetail from "features/company-detail";
import Township from "features/township"
import TownshipDetail from "features/township-detail";

const routes = [
  {
    type: "collapse",
    name: "Karolinska Institutet",
    key: "my-account",
    icon: <UserName />,
    collapse: [
      {
        name: "Logout",
        key: "profile-overview",
        type: "logout",
      },
    ],
  },
  {
    type: "tab",
    name: "Patients",
    key: "patients",
    fillter: "user",
    route: PAGES.patients,
    icon: <Icon fontSize="medium">medical_information</Icon>,
    component: <Patients />,
  },
  {
    type: "tab",
    name: "Analytics",
    key: "analytics",
    fillter: "user",
    route: PAGES.analytics,
    icon: <Icon fontSize="medium">analytics</Icon>,
    component: <Analytics />,
  },
  {
    type: "tab",
    name: "Statistics",
    key: "statistics",
    fillter: "user",
    route: PAGES.statistics,
    icon: <Icon fontSize="medium">data_usage</Icon>,
    component: <Statistics />,
  },
  {
    type: "tab",
    name: "Users",
    key: "users",
    fillter: "hospital",
    route: PAGES.users,
    icon: <Icon fontSize="medium">people</Icon>,
    component: <Users />,
  },
  {
    type: "tab",
    name: "Hospital",
    key: "hospital",
    fillter: "hospital",
    route: PAGES.hospital,
    icon: <Icon fontSize="medium">people</Icon>,
    component: <Hospital />,
  },
  {
    type: "tab",
    name: "Job",
    key: "job",
    fillter: "hospital",
    route: PAGES.job,
    icon: <Icon fontSize="medium">people</Icon>,
    component: <Job />,
  },
  {
    type: "tab",
    name: "Company",
    key: "company",
    fillter: "hospital",
    route: PAGES.company,
    icon: <Icon fontSize="medium">people</Icon>,
    component: <Company />,
  },
  {
    type: "tab",
    name: "Township",
    key: "township",
    fillter: "hospital",
    route: PAGES.township,
    icon: <Icon fontSize="medium">people</Icon>,
    component: <Township />,
  },
  {
    type: "tab",
    name: "Department",
    key: "department",
    fillter: "hospital",
    route: PAGES.department,
    icon: <Icon fontSize="medium">people</Icon>,
    component: <Department />,
  },
  {
    type: "tab",
    name: "Assessment",
    key: "assessment",
    fillter: "hospital",
    route: PAGES.assessment,
    icon: <Icon fontSize="medium">ballot</Icon>,
    component: <Assessment />,
  },
  {
    type: "tab",
    name: "References",
    key: "references",
    fillter: "hospital",
    route: PAGES.references,
    icon: <Icon fontSize="medium">ballot</Icon>,
    component: <References />,
  },
  // {
  //   type: "tab",
  //   name: "Manufacturer Dicom",
  //   key: "manufacturer-dicom",
  //   fillter: "hospital",
  //   route: PAGES.manufacturerDicom,
  //   icon: <Icon fontSize="medium">ballot</Icon>,
  //   component: <ManufacturerDicom />,
  // },
  // {
  //   type: "tab",
  //   name: "Export Data",
  //   key: "export-data",
  //   fillter: "hospital",
  //   route: PAGES.exportData,
  //   icon: <Icon fontSize="medium">ballot</Icon>,
  //   component: <ExportData />,
  // },
  {
    type: "tab",
    name: "Settings",
    key: "settings",
    fillter: "hospital",
    route: PAGES.settings,
    icon: <Icon fontSize="medium">ballot</Icon>,
    component: <ParameterSettings />,
  },
  {
    type: "tab",
    name: "Finding Structure",
    key: "finding-structure",
    fillter: "hospital",
    route: PAGES.findingStructure,
    icon: <Icon fontSize="medium">ballot</Icon>,
    component: <FindingStructure />,
  },
  {
    type: "page",
    key: "finding-structure",
    route: PAGES.newFinding,
    component: <FindingDetail />,
  },
  {
    type: "page",
    key: "finding-structure",
    route: `${PAGES.editFinding}/:id`,
    component: <FindingDetail />,
  },
  {
    type: "page",
    key: "new-assessment",
    route: PAGES.newAssessment,
    component: <AssessmentDetail />,
  },
  {
    type: "page",
    key: "edit-assessment",
    route: `${PAGES.editAssessment}/:id`,
    component: <AssessmentDetail />,
  },
  {
    type: "page",
    key: "new-references",
    route: PAGES.newReferences,
    component: <ReferencesDetail />,
  },
  {
    type: "page",
    key: "edit-references",
    route: `${PAGES.editReferences}/:id`,
    component: <ReferencesDetail />,
  },
  {
    type: "page",
    key: "new-job",
    route: PAGES.newJob,
    component: <JobDetail />,
  },
  {
    type: "page",
    key: "edit-jobs",
    route: `${PAGES.editJob}/:id`,
    component: <JobDetail />,
  },
  {
    type: "page",
    key: "new-company",
    route: PAGES.newCompany,
    component: <CompanyDetail />,
  },
  {
    type: "page",
    key: "edit-companies",
    route: `${PAGES.editCompany}/:id`,
    component: <CompanyDetail />,
  },
  {
    type: "page",
    key: "new-township",
    route: PAGES.newTownship,
    component: <TownshipDetail />,
  },
  {
    type: "page",
    key: "edit-townships",
    route: `${PAGES.editTownship}/:id`,
    component: <TownshipDetail />,
  },
  {
    type: "page",
    key: "new-manufacturer-dicom",
    route: PAGES.newManufacturerDicom,
    component: <ManufacturerDicomDetail />,
  },
  {
    type: "page",
    key: "edit-manufacturer-dicom",
    route: `${PAGES.editManufacturerDicom}/:id`,
    component: <ManufacturerDicomDetail />,
  },
  {
    type: "page",
    key: "settings",
    route: PAGES.newSettings,
    component: <ParameterSettingsDetail />,
  },
  {
    type: "page",
    key: "settings",
    route: `${PAGES.editSettings}/:id`,
    component: <ParameterSettingsDetail />,
  },
  // {
  //   type: "tab",
  //   name: "Sections",
  //   key: "sections",
  //   route: PAGES.sessions,
  //   icon: <Icon fontSize="medium">ballot</Icon>,
  //   component: <Sessions />,
  // },
  // {
  //   type: "tab",
  //   name: "Parameters",
  //   key: "parameters",
  //   route: PAGES.parameters,
  //   icon: <Icon fontSize="medium">toc</Icon>,
  //   component: <Parameters />,
  // },
  {
    type: "tab",
    name: "Scripts",
    key: "scripts",
    fillter: "hospital",
    route: PAGES.python,
    icon: <Icon fontSize="medium">description</Icon>,
    component: <Python />,
  },

  { type: "divider", key: "divider-1" },
  // single pages
  {
    type: "page",
    key: "patient-finding",
    route: `${PAGES.patientFinding}/:hospitalId/:id`,
    // icon: <Icon fontSize="medium">medical_information</Icon>,
    component: <PatientFinding />,
  },
  {
    type: "page",
    key: "new-user",
    route: PAGES.newUser,
    component: <UserDetail />,
  },
  {
    type: "page",
    key: "new-hospital",
    route: PAGES.newHospital,
    component: <HospitalDetail />,
  },
  {
    type: "page",
    key: "new-department",
    route: PAGES.newDepartment,
    component: <DepartmentDetail />,
  },
  {
    type: "page",
    key: "edit-user",
    route: `${PAGES.editUser}/:id`,
    component: <UserDetail />,
  },
  {
    type: "page",
    key: "edit-hospital",
    route: `${PAGES.editHospital}/:id`,
    component: <HospitalDetail />,
  },
  {
    type: "page",
    key: "edit-department",
    route: `${PAGES.editDepartment}/:id`,
    component: <DepartmentDetail />,
  },
  {
    type: "page",
    key: "patients",
    route: `${PAGES.editExam}/:hospitalId/:id`,
    component: <ExamDetail />,
  },
];

export default routes;
