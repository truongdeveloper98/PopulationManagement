// ClientApp/src/setLicense.js
import { LicenseManager } from 'ag-grid-enterprise';

// Correctly wrap the hardcoded license key in quotes (if used directly)
LicenseManager.setLicenseKey(
  "Using_this_{AG_Grid}_Enterprise_key_{AG-074842}_in_excess_of_the_licence_granted_is_not_permitted___Please_report_misuse_to_legal@ag-grid.com___For_help_with_changing_this_key_please_contact_info@ag-grid.com___{MARS_CODE_SOLUTION}_is_granted_a_{Single_Application}_Developer_License_for_the_application_{SWECVI}_only_for_{1}_Front-End_JavaScript_developer___All_Front-End_JavaScript_developers_working_on_{SWECVI}_need_to_be_licensed___{SWECVI}_has_not_been_granted_a_Deployment_License_Add-on___This_key_works_with_{AG_Grid}_Enterprise_versions_released_before_{12_January_2026}____[v3]_[01]_MTc2ODE3NjAwMDAwMA==ce3b8b80f93c48bfe1a0ca1681455a2d"
);

// If using an environment variable for the license key
const licenseKey = process.env.REACT_APP_AG_GRID_LICENSE_KEY;

// Only set the environment-based license key if it's defined
if (licenseKey) {
  LicenseManager.setLicenseKey(licenseKey);
} else {
  console.warn("AG Grid license key is not defined in environment variables.");
}
