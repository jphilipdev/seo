import { connect } from 'react-redux';
import { google } from '../store/selectors/searchSelectors';
import GoogleSearch from '../components/GoogleSearch';

const mapStateToProps = state => ({
  googleKeywords: google(state)
});

export default connect(
  mapStateToProps
)(GoogleSearch);