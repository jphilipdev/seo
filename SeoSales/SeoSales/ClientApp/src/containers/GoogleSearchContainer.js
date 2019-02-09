import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { googleResults, googleSearchError } from '../store/selectors/searchSelectors';
import { searchGoogle } from '../store/thunks/searchThunks';
import GoogleSearch from '../components/search/GoogleSearch';

const mapStateToProps = state => ({
  googleResults: googleResults(state),
  googleSearchError: googleSearchError(state)
});

const mapDispatchToProps = dispatch => bindActionCreators({
  searchGoogle
}, dispatch)

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(GoogleSearch);