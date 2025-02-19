import {
  ArrowBackIos, ArrowForwardIos, FirstPage, LastPage,
} from '@mui/icons-material';
import { IconButton } from '@mui/material';
import { useTranslation } from 'react-i18next';
import { useMaterialUIController } from 'context';

import styles from './styles.module.css';

function Pagination({
  entity, previousPage, gotoPage, nextPage,
}) {
  const { t } = useTranslation();
  const [controller] = useMaterialUIController();
  const { darkMode } = controller;

  const handleGoToFirst = () => {
    gotoPage(0);
  };

  const handleGoToLast = () => {
    gotoPage(entity.totalPages - 1);
  };

  return (
    <div className={`${styles.pagination} ${darkMode && styles.darkMode}`}>
      <div className={styles.label}>
        <strong>
          {entity.page !== undefined && entity.totalItems > 0 ? entity.page * entity.limit + 1 : 0}
        </strong>
        {' '}
        {t('To').toLowerCase()}
        {' '}
        <strong>
          {entity.page !== undefined
            ? Math.min((entity.page + 1) * entity.limit, entity.totalItems)
            : 0}
        </strong>
        {' '}
        {t('Of').toLowerCase()}
        {' '}
        <strong>{entity.totalItems ?? 0}</strong>
      </div>

      <div className={styles.action}>
        <IconButton
          className={styles.actionItem}
          disabled={entity.page === 0}
          onClick={handleGoToFirst}
        >
          <FirstPage />
        </IconButton>

        <IconButton
          className={styles.actionItem}
          onClick={previousPage}
          disabled={entity.page === 0}
        >
          <ArrowBackIos fontSize="small" />
        </IconButton>

        <div className={styles.page}>
          {t('Page')}
          {' '}
          <strong>
            {entity.page !== undefined && entity.totalPages > 0 ? entity.page + 1 : 0}
          </strong>
          {' '}
          {t('Of').toLowerCase()}
          {' '}
          <strong>{entity.totalPages ?? 0}</strong>
        </div>

        <IconButton
          className={styles.actionItem}
          onClick={nextPage}
          disabled={entity.page === entity.totalPages - 1}
        >
          <ArrowForwardIos fontSize="small" />
        </IconButton>

        <IconButton
          className={styles.actionItem}
          disabled={entity.page === entity.totalPages - 1}
          onClick={handleGoToLast}
        >
          <LastPage />
        </IconButton>
      </div>
    </div>
  );
}

export default Pagination;
