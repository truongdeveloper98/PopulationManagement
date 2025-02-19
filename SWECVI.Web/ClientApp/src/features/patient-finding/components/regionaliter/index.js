import { ArrowBack, ArrowForward } from '@mui/icons-material';
import {
  Box, Card, Grid, IconButton,
} from '@mui/material';
import BoxFinding from 'components/Customized/BoxFinding';
import MDButton from 'components/MDButton';
import TabItem from './components/TabItem';
import useRegionaliter from './hooks/useRegionaliter';
import './styles.css';

export default function Regionaliteter({ patientFindingBox, handleSave }) {
  const {
    handleTabChange,
    tabIndex,
    segmentHeart,
    arrTab,
    midpoint,
    handleClear,
    handleAllNormal,
  } = useRegionaliter(patientFindingBox, handleSave);

  return (
    <>
      <Box display="flex" sx={{ my: 2 }}>
        <MDButton variant="gradient" color="success" onClick={handleAllNormal}>
          All segments normal
        </MDButton>
        <Box sx={{ m: 1 }} />
        <MDButton variant="gradient" color="secondary" onClick={handleClear}>
          Clear
        </MDButton>
      </Box>

      <Card sx={{ p: 2, mb: 1 }}>
        <Box sx={{ display: 'flex', mb: 1 }}>
          {arrTab.map((tab, index) => (
            <Box key={tab} sx={{ display: 'flex' }}>
              <TabItem name={tab} active={tabIndex === index} />
              <Box sx={{ m: 1 }} />
            </Box>
          ))}
        </Box>

        <Grid container spacing={2} className="tab-content">
          <Grid item xs={4} sx={{ mt: 2 }}>
            <BoxFinding
              boxHeader=""
              inputPatientFinding={segmentHeart.slice(0, midpoint)}
              tabName="Regionalitet"
            />
          </Grid>

          <Grid item xs={4}>
            <Box sx={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
              <img
                src={
                  segmentHeart?.image
                  ?? 'https://www.crossfit.com/wp-content/uploads/2020/08/30131527/CF_Heart_Segments_r1-768x768.png'
                }
                alt="segment-heart"
                width="100%"
              />

              <Box sx={{ display: 'flex' }}>
                <IconButton
                  sx={{}}
                  onClick={() => handleTabChange(tabIndex - 1)}
                  disabled={tabIndex === 0}
                >
                  <ArrowBack />
                </IconButton>

                <Box sx={{ m: 3 }} />

                <IconButton
                  sx={{}}
                  onClick={() => handleTabChange(tabIndex + 1)}
                  disabled={tabIndex === arrTab.length - 1}
                >
                  <ArrowForward />
                </IconButton>
              </Box>
            </Box>
          </Grid>

          <Grid item xs={4}>
            <BoxFinding
              boxHeader=""
              inputPatientFinding={segmentHeart.slice(midpoint, segmentHeart.length)}
              tabName="Regionalitet"
            />
          </Grid>
        </Grid>
      </Card>
    </>
  );
}
