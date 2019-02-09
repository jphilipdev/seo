import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { google } from '../store/selectors/searchSelectors';
import { searchGoogle } from '../store/thunks/searchThunks';
import GoogleSearch from '../components/GoogleSearch';

const mapStateToProps = state => ({
  googleResults: google(state)
});

const mapDispatchToProps = dispatch => bindActionCreators({
  searchGoogle
}, dispatch)

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(GoogleSearch);